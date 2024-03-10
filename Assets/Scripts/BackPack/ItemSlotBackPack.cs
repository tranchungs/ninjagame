using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotBackPack
{
    public ItemSO Item;
    public int amount;
    public ItemSlotBackPack(ItemSO Item, int amount)
    {
        this.Item = Item;
        this.amount = amount;
    }
}