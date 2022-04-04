using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgress : MonoBehaviour
{
    private void Update()
    {
        if (GameController.Instance.CoinsToCollect==0)
        {
            Debug.Log("end");
            GameController.Instance.isPlaying = false;
        }
    }
}
