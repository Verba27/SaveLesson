using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance
    {
        get
        {
            if (instance != null)
            {
                return instance;
            }

            instance = FindObjectOfType<GameController>();
            if (instance != null)
            {
                instance.Init();
                return instance;
            }

            instance = new GameObject("GameController").AddComponent<GameController>();
            instance.Init();
            return instance;
        }
    }

    private static GameController instance;

    private void Awake()
    {
        if (instance == null)
        {
            Init();
        }
        
        DontDestroyOnLoad(this);
    }
    private void Init()
    {
        instance = this;
    }


    [SerializeField] private GameConfig gameConfig;
    public int LevelToPlay { get; set; }
    public int CoinsToCollect { get; set; }
    public int CoinsInBag { get; set; }
    public int PotionsInBag { get; set; }
    public int CurrentHealts { get; set; }

    public List<Vector3> coinsPos;
    public List<Vector3> potsPos;
    public List<Vector3> trapsPos;

    private GameObject player;
    public GameObject Player => player;
    
    public bool isPlaying = true;

    private void Start()
    {
        isPlaying = true;
        coinsPos = new List<Vector3>();
        potsPos = new List<Vector3>();
        trapsPos = new List<Vector3>();
    }

    public void SetPlayer(GameObject obj)
    {
        player = obj;
    }
    
    
    public void NextLevel()
    {
        LevelToPlay++;
    }

    private void Update()
    {
        if (CurrentHealts == 0)
        {
            //isPlaying = false;
        }
    }

    public void StartGame()
    {
        CoinsToCollect = gameConfig.LevelConfigs[LevelToPlay].CoinsOnLevel;
        isPlaying = true;
    }

    public void SaveData()
    {
        var myData = new GameData();
        myData._coinsInBag = CoinsInBag;
        myData._potionsInBag = PotionsInBag;
        // myData._coinsPosition = coinsPos;
        // myData._potionsPosition = potsPos;
        // myData._trapsPosition = trapsPos;
        myData._playerPositionX = (int) player.transform.position.x;
        myData._playerPositionZ = (int) player.transform.position.z;
        myData._playerRotationY = (int) player.transform.rotation.y;

        string dataToSave = JsonConvert.SerializeObject(myData);
        File.WriteAllText(Application.persistentDataPath + Path.PathSeparator + "save_data.json",dataToSave);
    }

    public void LoadData()
    {
        
        string sd = File.ReadAllText(Application.persistentDataPath + Path.PathSeparator + "save_data.json");
        Debug.Log(sd);
    }
}