using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopNPC : MonoBehaviour
{
    [SerializeField] private NPC_Merchant NPC_Merchant;
    [SerializeField] private GameObject capacity;
    private ItemSO itemSelected;
    private void OnEnable()
    {
        RenderShop();
    }
    private void RenderShop()
    {

        for (int i = 0; i < NPC_Merchant.GetListMedicines().Count; i++)
        {

            MedicineSO medicineSO = NPC_Merchant.GetListMedicines()[i];
            ItemSlot itemslot = capacity.transform.GetChild(i).GetComponent<ItemSlot>();
            itemslot.SetIndex(i);
            itemslot.SetItem(medicineSO);
            itemslot.SetIcon(medicineSO.sprite);
            itemslot.OnSlectedItem += Itemslot_OnSlectedItem;

        }
    }
    
    private void Itemslot_OnSlectedItem(object sender, ItemSlot.OnSlectedItemArgs e)
    {
        Debug.Log(e.index);
        itemSelected = NPC_Merchant.GetListMedicines()[e.index];
    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
        itemSelected = null;
    }
    public void Sell()
    {
        if (itemSelected != null)
        {
            NPC_Merchant.GetPlayerInteract().Buy(itemSelected);
        }
       
    }
}
