using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KPModules.Utilities;
using KPModules.Collectible;
using KPModules.Data;
using System.IO;

[RequireComponent(typeof(UnityEngine.PlayerLoop.Initialization))]
public class DataController //: Singleton<SDataController>
{
    private DataInitalizer<GameData> dataInitalizer;
    private string KEY = "AlienSurvival";
    public GameData GameData => dataInitalizer.Data;

    protected void Awake()
    {
        dataInitalizer = new DataInitalizer<GameData>(KEY, "data.dat");
#if !UNITY_EDITOR
            Application.targetFrameRate=60;
#endif
    }
    public void LoadData()
    {
        dataInitalizer.LoadData();
    }
    public void SaveData()
    {
        dataInitalizer.SaveData();
    }
    public void ResetData()
    {
        dataInitalizer.ResetData();
    }
    public Collectible GetCollectibleById(int id)
    {
        foreach (var _collectible in GameData.collectibles)
            if (_collectible.id == id) return _collectible;
        var collectible = new Collectible();
        collectible.id = id;
        collectible.amount = 0;
        GameData.collectibles.Add(collectible);
        return collectible;
    }

    private void OnEnable()
    {
        dataInitalizer.LoadData();
    }
}

[System.Serializable]
public class GameData : Data
{
    public List<Collectible> collectibles;

    public GameData()
    {
        Reset();
    }

    public override void Reset()
    {
        this.collectibles = new List<Collectible>();
    }
}

