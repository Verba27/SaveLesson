using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerInventory playerInventory;

    [SerializeField] private LevelFiller levelFiller;
    private int health = 100;

    public int Health => health;
    private Vector2 turn;

    private void Start()
    {
        GameController.Instance.SetPlayer(gameObject);
    }

    private void Update()
    {
        var valueVert = Input.GetAxis("Vertical");
        var valueHoriz = Input.GetAxis("Horizontal");

        turn.x += Input.GetAxis("Mouse X");

        transform.localRotation = Quaternion.Euler(0,turn.x, 0);
        if (valueVert != 0)
        {
            transform.position += transform.forward * valueVert * Time.deltaTime * 5;

        }
        if (valueHoriz != 0)
        {
            transform.position += transform.right * valueHoriz * Time.deltaTime * 5;

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (playerInventory.Potions > 0)
            {
                playerInventory.ConsumePotion();
                ChangeHealts(30);
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            GameController.Instance.SaveData();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            GameController.Instance.LoadData();
        }
    }

    public void ChangeHealts(int value)
    {
        health += value;
        health = Mathf.Clamp(health,0,100);
        GameController.Instance.CurrentHealts = health;

        Debug.Log($"health - {health}");
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Items>().Type == ItemTypes.potion)
        {
            Destroy(other.gameObject);
            playerInventory.PickupPotion();
            GameController.Instance.potsPos.Remove(other.gameObject.transform.position);
        }
        if (other.gameObject.GetComponent<Items>().Type == ItemTypes.coin)
        {
            Destroy(other.gameObject);
            playerInventory.ChangeCoinsCount(1);
            levelFiller.CoinsToCollect.Remove(other.gameObject.transform.position);
            GameController.Instance.coinsPos.Remove(other.gameObject.transform.position);
        }

        if (other.gameObject.GetComponent<Items>().Type == ItemTypes.trap)
        {
            ChangeHealts(-20);
        }
    }
}
