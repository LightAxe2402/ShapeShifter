﻿using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataTracker : MonoBehaviour
{
    public static DataTracker dataTracker = null;
    public static GameData gameData = null;

    private string filePath => Application.persistentDataPath + "/playerData.dat";

    private void Awake()
    {
        if (dataTracker == null)
        {
            dataTracker = this;
            gameData = new GameData();

            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(filePath);

        bf.Serialize(file, gameData);
        file.Close();
    }

    public void LoadData()
    {
        if (File.Exists(filePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);

            gameData = (GameData)bf.Deserialize(file);
            file.Close();
        }
    }
}

[System.Serializable]
public class GameData
{
    public bool initialTutorialComplete = false;
    public float levelsCompleted = 0;
}