using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int coins;
    private int potions;
    public int Potions => potions;

    private void Start()
    {
        coins = GameController.Instance.CoinsInBag;
        potions = GameController.Instance.PotionsInBag;
    }

    public void ChangeCoinsCount(int value)
    {
        coins += value;
        GameController.Instance.CoinsInBag = coins;
        GameController.Instance.CoinsToCollect--;
        Debug.Log(GameController.Instance.CoinsToCollect);
        Debug.Log("Toss a coin to your witcher!");
    }

    public void PickupPotion()
    {
        potions++;
        GameController.Instance.PotionsInBag = potions;
        Debug.Log($"potions - {potions}");
    }

    public void ConsumePotion()
    {
        potions--;
        GameController.Instance.PotionsInBag = potions;

        Debug.Log($"potions - {potions}");

    }

}
