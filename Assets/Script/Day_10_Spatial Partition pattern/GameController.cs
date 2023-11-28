using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GDD
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Vector2 vision_distance;
        public GameObject friendlyObj;
        public GameObject enemyObj;
        
        //Change materials to detect which enemy is the closest
        public Material enemyMaterial;
        public Material closestEnemyMaterial;
        
        //To get a cleaner workspace, parent all soldiers to these empty gameobjects
        public Transform enemyParent;
        public Transform friendlyParent;
        
        //Store all soldiers in these lists
        List<Soldier> enemySoldiers = new List<Soldier>();
        List<Soldier> friendlySoldiers = new List<Soldier>();
        
        //Save the closest enemies to easier change back its material
        List<Soldier> closestEnemies = new List<Soldier>();

        //Grid data
        float mapWidth = 50f;
        int cellSize = 10;

        //Number of soldiers on each team
        int numberOfSoldiers = 10;
        int numberOfPlayer = 1;

        //The Spatial Partition grid
        Grid grid;

		
        void Start() 
        {
            //Create a new grid
            grid = new Grid((int)mapWidth, cellSize);
            
            //Add random enemies and friendly and store them in a list
            for (int i = 0; i < numberOfSoldiers; i++)
            {
                //Give the enemy a random position
                Vector3 randomPos = new Vector3(Random.Range(0f, mapWidth), 0.5f, Random.Range(0f, mapWidth));

                //Create a new enemy
                GameObject newEnemy = Instantiate(enemyObj, randomPos, Quaternion.identity) as GameObject;

                //Add the enemy to a list
                enemySoldiers.Add(new Enemy_SPP(newEnemy, mapWidth, grid));

                //Parent it
                newEnemy.transform.parent = enemyParent;
            }
            
            for (int i = 0; i < numberOfPlayer; i++)
            {
                //Give the friendly a random position
                Vector3 randomPos = new Vector3(Random.Range(0f, mapWidth), 0.5f, Random.Range(0f, mapWidth));

                //Create a new friendly
                GameObject newFriendly = Instantiate(friendlyObj, randomPos, Quaternion.identity) as GameObject;

                //Add the friendly to a list
                friendlySoldiers.Add(new Player_SPP(newFriendly, mapWidth, vision_distance));

                //Parent it 
                newFriendly.transform.parent = friendlyParent;
            }
        }
	
	
        void Update() 
        {
            //Move the enemies
            for (int i = 0; i < enemySoldiers.Count; i++)
            {
                enemySoldiers[i].Move();
            }

            //Reset material of the closest enemies
            for (int i = 0; i < closestEnemies.Count; i++)
            {
                closestEnemies[i].soldierMeshRenderer.material = enemyMaterial;
            }

            //Reset the list with closest enemies
            closestEnemies.Clear();

            //For each friendly, find the closest enemy and change its color and chase it
            for (int i = 0; i < friendlySoldiers.Count; i++)
            {
                //Soldier closestEnemy = FindClosestEnemySlow(friendlySoldiers[i]);

                //The fast version with spatial partition
                Soldier closestEnemy = grid.FindClosestEnemy(friendlySoldiers[i]);

                //If we found an enemy
                if (closestEnemy != null)
                {
                    //Change material
                    closestEnemy.soldierMeshRenderer.material = closestEnemyMaterial;

                    closestEnemies.Add(closestEnemy);

                    //Move the friendly in the direction of the enemy
                    friendlySoldiers[i].Move(closestEnemy);
                }
            }
        }

        void OnDrawGizmosSelected()
        {
            foreach (var soldier in friendlySoldiers)
            {
                Vector2 vision = soldier.vision / 2;
                //Determine which grid cell the friendly soldier is in
                float cellX = soldier.soldierTrans.position.x;
                float cellZ = soldier.soldierTrans.position.z;
                Vector2[] cells_pos = new Vector2[4];
                cells_pos[0] = new Vector2(cellX + vision.x, cellZ - vision.y);
                cells_pos[1] = new Vector2(cellX + vision.x, cellZ + vision.y);
                cells_pos[2] = new Vector2(cellX - vision.x, cellZ + vision.y);
                cells_pos[3] = new Vector2(cellX - vision.x, cellZ - vision.y);
                
                Gizmos.color = new Color(0, 1, 0, 0.5f);
                Gizmos.DrawCube(soldier.soldierTrans.position, new Vector3(soldier.vision.x, 1, soldier.vision.y));
                
                
                int[,] cells_pos_map = new int[4, 2]
                {
                    { (int)((cellX + vision.x) / cellSize), (int)((cellZ - vision.y) / cellSize)},
                    { (int)((cellX + vision.x) / cellSize), (int)((cellZ + vision.y) / cellSize)},
                    { (int)((cellX - vision.x) / cellSize), (int)((cellZ + vision.y) / cellSize)},
                    { (int)((cellX - vision.x) / cellSize), (int)((cellZ - vision.y) / cellSize)}
                };
                
                Gizmos.color = new Color(0, 0, 1, 0.5f);
                for (int i = 0; i < cells_pos_map.Length / 2; i++)
                {
                    Gizmos.DrawCube(new Vector3(cells_pos_map[i, 0] * cellSize + (5f), 0, cells_pos_map[i, 1] * cellSize + (5f)), new Vector3(1, 1, 1));
                }
                
                Gizmos.color = new Color(1, 0, 0, 0.5f);
                int _i = 1;
                foreach (var cell in cells_pos)
                {
                    if(_i > cells_pos.Length - 1)
                        Gizmos.DrawLine(new Vector3(cell.x, 0.1f, cell.y), new Vector3(cells_pos[0].x, 0.1f, cells_pos[0].y));
                    else
                        Gizmos.DrawLine(new Vector3(cell.x, 0.1f, cell.y), new Vector3(cells_pos[_i].x, 0.1f, cells_pos[_i].y));
                    
                    _i++;
                }
            }
        }

        //Find the closest enemy - slow version
        Soldier FindClosestEnemySlow(Soldier soldier)
        {
            Soldier closestEnemy = null;

            float bestDistSqr = Mathf.Infinity;

            //Loop thorugh all enemies
            for (int i = 0; i < enemySoldiers.Count; i++)
            {
                //The distance sqr between the soldier and this enemy
                float distSqr = (soldier.soldierTrans.position - enemySoldiers[i].soldierTrans.position).sqrMagnitude;

                //If this distance is better than the previous best distance, then we have found an enemy that's closer
                if (distSqr < bestDistSqr)
                {
                    bestDistSqr = distSqr;

                    closestEnemy = enemySoldiers[i];
                }
            }

            return closestEnemy;
        }
    }
}