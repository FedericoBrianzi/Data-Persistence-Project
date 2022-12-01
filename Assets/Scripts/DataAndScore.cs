using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataAndScore : MonoBehaviour
{
    public static DataAndScore Instance;

    public string playerName;
    public int BestScore = 0;
    public string BestScoreName;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    [Serializable]
    class PersistentData
    {
        public int score;
        public string name;
    }

    public void SaveData()
    {
        PersistentData data = new PersistentData();
        data.score = BestScore;
        data.name = BestScoreName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PersistentData data = JsonUtility.FromJson<PersistentData>(json);

            BestScore = data.score;
            BestScoreName = data.name;
        }
    }
}
