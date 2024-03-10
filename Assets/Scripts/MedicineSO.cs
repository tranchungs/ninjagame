using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MedicineSO", menuName = "ScriptableObject / Medicine")]
public class MedicineSO : ItemSO
{
    public int effectValue;
    public int price;
    public PotionType typePotion;
}
public enum PotionType
{
    HP,
    MP
}