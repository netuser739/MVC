using System.IO;
using UnityEngine;

namespace Game
{
    public class JSONBonudData : ISaveData
    {
        string SavePath;

        public JSONBonudData(string path)
        {
            SavePath = Path.Combine(Application.dataPath, path);
        }

        public void Save(BonusData bonus)
        {
            string FileJson = JsonUtility.ToJson(bonus);
            File.WriteAllText(SavePath, FileJson);
        }

        public BonusData LoadBonus()
        {
            BonusData result = new BonusData();
            if (!File.Exists(SavePath))
            {
                Debug.Log("File NOT Exists");
                return result;
            }

            string json = File.ReadAllText(SavePath);
            result = JsonUtility.FromJson<BonusData>(json);
            return result;
        }

        public void Save(PlayerData bonus)
        {

        }

        public PlayerData Load()
        {
            return new PlayerData();
        }
    }
}