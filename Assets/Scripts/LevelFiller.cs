using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelFiller : MonoBehaviour
{
    [SerializeField] private GameConfig gameConfig;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject potionPrefab;
    [SerializeField] private GameObject trapPrefab;

    private List<Vector3> coinsList;
    public List<Vector3> CoinsToCollect => coinsList;
    private List<Vector3> positionsOccupied;
    private List<Vector3> potionsList;
    private List<Vector3> trapsList;
    private Vector3 posToSpawn;

    private void Start()
    {
        coinsList = new List<Vector3>();
        positionsOccupied = new List<Vector3>();
        potionsList = new List<Vector3>();
        trapsList = new List<Vector3>();
        FillLevel(GameController.Instance.LevelToPlay);
        
    }

    public void FillLevel(int levelNumber)
    {
        for (int i = 0; i < gameConfig.LevelConfigs[levelNumber].CoinsOnLevel; i++)
        {
            CheckExistPos();
            var coin = Instantiate(coinPrefab, posToSpawn, Quaternion.identity);
            coinsList.Add(coin.transform.position);
            GameController.Instance.CoinsToCollect = coinsList.Count;
            positionsOccupied.Add(coin.transform.position);
            GameController.Instance.coinsPos = coinsList;

        }
        for (int i = 0; i < gameConfig.LevelConfigs[levelNumber].PotionsOnLevel; i++)
        {
            CheckExistPos();
            var pot = Instantiate(potionPrefab, posToSpawn, Quaternion.identity);
            potionsList.Add(pot.transform.position);
            positionsOccupied.Add(pot.transform.position);
            GameController.Instance.potsPos = potionsList;
        }
        for (int i = 0; i < gameConfig.LevelConfigs[levelNumber].TrapsOnLevel; i++)
        {
            CheckExistPos();
            var trap = Instantiate(trapPrefab, posToSpawn, Quaternion.identity);
            trapsList.Add(trap.transform.position);
            positionsOccupied.Add(trap.transform.position);
            GameController.Instance.trapsPos = trapsList;

        }
        positionsOccupied.Clear();
    }

    public Vector3 GetRandomPosition()
    {
        var posX = Random.Range(-10, 10);
        var posZ = Random.Range(-10, 10);
        return new Vector3(posX, 1, posZ);
    }

    public bool CheckExistPos()
    {
        posToSpawn = GetRandomPosition();
        if (!positionsOccupied.Contains(posToSpawn))
        {
            if (posToSpawn == Vector3.zero)
            {
                return false;
            }
            return true;
            
        }
        else
        {
            return false;
        }
    }
}
