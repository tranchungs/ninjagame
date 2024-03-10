using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSO : ScriptableObject
{
    public string name;
    public Sprite sprite;
    public int amount = 1;
    public ItemType type;
}
public enum ItemType
{
    WEAPON,
    MEDICINE,
    FOOD
}
