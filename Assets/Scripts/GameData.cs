using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public int _coinsInBag;
    public int _potionsInBag;
    
    public int _playerPositionX;
    public int _playerPositionZ;
    public int _playerRotationY;
    
    public List<Vector3> _coinsPosition;
    public List<Vector3> _potionsPosition;
    public List<Vector3> _trapsPosition;

}