using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDD
{
    public class Player_SPP : Soldier
    {
        //init friendly
        public Player_SPP(GameObject soldierObj, float mapWidth, Vector2 vision)
        {
            this.soldierTrans = soldierObj.transform;

            this.walkSpeed = 2f;

            this.vision = vision;
        }


        //Move towards the closest enemy - will always move within its grid
        public override void Move(Soldier closestEnemy)
        {
            //Rotate towards the closest enemy
            soldierTrans.rotation = Quaternion.LookRotation(closestEnemy.soldierTrans.position - soldierTrans.position);
            //Move towards the closest enemy
            soldierTrans.Translate(Vector3.forward * Time.deltaTime * walkSpeed);
        }
    }
}