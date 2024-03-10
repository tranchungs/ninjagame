using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.U2D;

public class ItemSlot : MonoBehaviour
{
    public event EventHandler<OnSlectedItemArgs> OnSlectedItem;
    public class OnSlectedItemArgs : EventArgs
    {
        public int index;
    }
    private ItemSO Item;
    private int index;
    [SerializeField] private GameObject Icon;
    [SerializeField] private TextMeshProUGUI textAmount;

  
    public void SetIcon(Sprite image)
    {
        Color color = new Color(255, 255, 255, 255);
        Icon.GetComponent<Image>().sprite = image;
        Icon.GetComponent<Image>().color = color;
    }
 
    public void SetAmount(int amount)
    {
        if (amount == 1)
        {
            textAmount.SetText("");
        }
        else
        {
            textAmount.SetText(amount.ToString());
        }
      
    }
    public void SetItem(ItemSO item)
    {
        this.Item = item;
    }
    public ItemSO GetItem()
    {
      return this.Item;
    }
    public void OnSelected()
    {
        OnSlectedItem?.Invoke(this, new OnSlectedItemArgs { index = this.index});
    }
    public void SetIndex(int index)
    {
        this.index  = index;
    }

}
