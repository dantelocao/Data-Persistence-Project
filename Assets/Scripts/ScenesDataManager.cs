using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScenesDataManager : MonoBehaviour
{
    public static ScenesDataManager instance;

    public string playerName;
    public int playerPoints;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    public class SaveData
    {
        public string playerName;
        public int playerPoints;
    }

    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.playerPoints = playerPoints;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public SaveData LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            SaveData returnData = new SaveData();      
            
            returnData.playerPoints = data.playerPoints;
            returnData.playerName = data.playerName;

            return returnData;
        }
        return null;
    }

    public void SaveBestPlayer()
    {
        SaveData bestScore = LoadPlayerData();

        if (bestScore != null)
        {
            if (playerPoints > bestScore.playerPoints)
            {
                SavePlayerData();
            }

        }
        else
        {
            SavePlayerData();
        }
    }
}
