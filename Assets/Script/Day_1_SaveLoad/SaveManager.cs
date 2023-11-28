using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;
using Unity.VisualScripting;

namespace GDD
{
    public class SaveManager : Singleton<SaveManager>
    {
        public GamePreferencesData LoadGamePreferencesData(string location)
        {
            location += ".json";
            string json = "";
            StreamReader sr = new StreamReader(location);
            json = sr.ReadToEnd();
            sr.Close();

            GamePreferencesData GPD = new GamePreferencesData();
            GPD = JsonConvert.DeserializeObject<GamePreferencesData>(json);
            return GPD;
        }
        
        public T LoadGameData<T>(string location = "", string filename = "", bool isDefaultPath = true)
        {
            print("FileName : " + filename);
            print("location : " + location);
            if (isDefaultPath)
            {
                location = Application.persistentDataPath + "/" + filename + ".json";
            }
            else
            {
                location = filename + ".json";
            }
            
            string json = "";
            StreamReader sr = new StreamReader(location);
            json = sr.ReadToEnd();
            sr.Close();

            object data = JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore,
            });
            return (T)data;
        }

        public void SaveGamePreferencesData(GamePreferencesData gpd, string location)
        {
            location += ".json";
            string json = null;
            json = JsonConvert.SerializeObject(gpd);
            
            StreamWriter sw = new StreamWriter(location);
            sw.Write(json);
            sw.Close();
        }
        
        public void SaveGameData<T>(object save_data, string location = "", bool isDefaultPath = true)
        {
            if (isDefaultPath)
            {
                string date = "";

                foreach (var _datetime in DateTime.Now.ToString().Split("/"))
                {
                    if (_datetime.Split(":").Length > 0)
                    {
                        foreach (var _time in _datetime.Split(":"))
                        {
                            date += _time + "-";
                        }
                    }
                    else
                    {
                        date += _datetime + "-";
                    }
                }
                
                location = Application.persistentDataPath + "/" + date;
            }

            location += ".json";
            
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.TypeNameHandling = TypeNameHandling.Auto;
            serializer.Formatting = Formatting.Indented;
            
            StreamWriter sw = new StreamWriter(location);
            JsonWriter jw = new JsonTextWriter(sw);
            serializer.Serialize(jw, save_data, typeof(T));
            
            jw.Close();
            sw.Close();
        }
        
        public List<FileInfo> GetAllSaveGame(string location = default, bool isDefaultPath = false)
        {
            if(isDefaultPath)
                location = Application.persistentDataPath;
            
            var Info = new DirectoryInfo(location);
            var SaveGameInfo = Info.GetFiles("*.json*").OrderByDescending(f => f.LastWriteTime.Year <= 1601 ? f.CreationTime : f.LastWriteTime).ToList();
            //print("SGI : " + SaveGameInfo.Count);
            /**
            foreach (var SGI in SaveGameInfo)
            {
                print(SGI.Name.Split('.')[0]);
            }**/

            return SaveGameInfo;
        }

        public List<FileInfo> GetDataSaveGames(string location = "", bool isDefaultPath = true)
        {
            if(isDefaultPath)
                location = Application.persistentDataPath;
            
            var Info = new DirectoryInfo(location);
            var SaveGameInfo = Info.GetFiles("*.json*").OrderByDescending(f => f.LastWriteTime.Year <= 1601 ? f.CreationTime : f.LastWriteTime).ToList();
            return SaveGameInfo;
        }
    }
}
