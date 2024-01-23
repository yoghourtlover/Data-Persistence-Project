using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public string RecordName;
    public int Score;
    public string PlayerName;
    public static DataManager Instance;

    public class SaveData
    {
        public string RecordName;
        public int Score;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        loadRecord();
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    //Load the highest record and its player name
    public void loadRecord() 
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            RecordName = data.RecordName;
            Score = data.Score;
        }
        
    }
    //Save the record if it's the highest for now
    public void saveRecord(int currentScore)
    {
        if(currentScore > Score)
        {
            SaveData data = new SaveData();
            data.Score = currentScore;
            data.RecordName = PlayerName;
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }
}
