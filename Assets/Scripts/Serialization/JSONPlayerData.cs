using System.IO;
using UnityEngine;

namespace Game
{
    public class JSONPlayerData : ISaveData
    {
        string SavePath;

        public JSONPlayerData(string path)
        {
            SavePath = Path.Combine(Application.dataPath, path);
        }
        public void Save(PlayerData player)
        {
            string FileJson = JsonUtility.ToJson(player);
            File.WriteAllText(SavePath, FileJson);
        }

        public PlayerData Load()
        {
            PlayerData result = new PlayerData();
            if (!File.Exists(SavePath))
            {
                Debug.Log("File NOT EXIST");
                return result;
            }

            string json = File.ReadAllText(SavePath);
            result = JsonUtility.FromJson<PlayerData>(json);

            return result;
        }

        public void Save(BonusData bonus)
        {

        }

        public BonusData LoadBonus()
        {
            return new BonusData();
        }
    }
}