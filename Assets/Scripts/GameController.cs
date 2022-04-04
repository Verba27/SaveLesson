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

    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject potPrefab;
    [SerializeField] private GameObject trapPrefab;
    

    public List<Vector3> coinsPos;
    public List<Vector3> potsPos;
    public List<Vector3> trapsPos;

    private GameObject player;
    public GameObject Player => player;
    
    public bool isPlaying = true;

    private void Start()
    {
        isPlaying = true;
        // coinsPos = new List<Vector3>();
        // potsPos = new List<Vector3>();
        // trapsPos = new List<Vector3>();
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
        myData._coinsPosition = coinsPos;
        myData._potionsPosition = potsPos;
        myData._trapsPosition = trapsPos;
        myData._playerPositionX = (int) player.transform.position.x;
        myData._playerPositionZ = (int) player.transform.position.z;
        myData._playerRotationY = (int) player.transform.rotation.y;

        string dataToSave = JsonUtility.ToJson(myData);
        File.WriteAllText(Application.dataPath + "/save_data.json", dataToSave);
    }

    public void LoadData()
    {
        var path = Application.dataPath + "/save_data.json";
        GameData gameData = JsonUtility.FromJson<GameData>(path);
        CoinsInBag = gameData._coinsInBag;
        PotionsInBag = gameData._potionsInBag;
        coinsPos = gameData._coinsPosition;
        potsPos = gameData._potionsPosition;
        trapsPos = gameData._trapsPosition;
        for (int i = 0; i < coinsPos.Count; i++)
        {
            Instantiate(coinPrefab, coinsPos[i], Quaternion.identity);
        }
        for (int i = 0; i < potsPos.Count; i++)
        {
            Instantiate(potPrefab, potsPos[i], Quaternion.identity);
        }
        for (int i = 0; i < trapsPos.Count; i++)
        {
            Instantiate(trapPrefab, trapsPos[i], Quaternion.identity);
        }
    }
}