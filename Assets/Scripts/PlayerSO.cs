using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Player",menuName = "ScriptableObject/ PlayerSO")]
public class PlayerSO : ScriptableObject
{
    public float MaxHP;
    public float MaxMP;
    public float current_HP;
    public float current_MP;
    public int Coin = 10000;
    public float Dame;
}
