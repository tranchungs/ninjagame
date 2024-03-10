using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;


public class BackPack : MonoBehaviour
{
   
    [SerializeField] private Player player;
    [SerializeField] private GameObject capacity;
    [SerializeField] private GameObject btnEquip;
    [SerializeField] private GameObject btnDelete;
    private int indexSelected;
    private void Start()
    {
        player = player.GetComponent<Player>();
    }
    private void OnEnable()
    {
        RenderBackPack();
    }
    private void OnDisable()
    {
        HideButton();
    }

    private void RenderBackPack()
    {
        for (int i = 0; i < player.GetListItemBackPack().Count; i++)
        {

            ItemSO itemSlotBackPack = player.GetListItemBackPack()[i];
            ItemSlot itemslot = capacity.transform.GetChild(i).GetComponent<ItemSlot>();
            itemslot.SetIndex(i);
            itemslot.SetItem(itemSlotBackPack);
            itemslot.SetIcon(itemSlotBackPack.sprite);
            itemslot.SetAmount(itemSlotBackPack.amount);
            itemslot.OnSlectedItem += Itemslot_OnSlectedItem;
           
        }
    }
   

    private void Itemslot_OnSlectedItem(object sender, ItemSlot.OnSlectedItemArgs e)
    {
        ShowButton();
        indexSelected = e.index;
    }
    public void Equip()
    {
        ItemSO itemSO = player.GetListItemBackPack()[indexSelected];
        switch (itemSO.type)
        {
            case ItemType.WEAPON:
                player.SetWeapon((WeaponSO)itemSO);
                break;
            case ItemType.MEDICINE :
                player.UsePotion((MedicineSO)itemSO, indexSelected);
              
                
                break;
        }
      
        // event
     


    }
    private void ShowButton()
    {
        btnEquip.SetActive(true);
        btnDelete.SetActive(true);
    }
    private void HideButton()
    {
        btnEquip.SetActive(false);
        btnDelete.SetActive(false);
    }
    private void OnDestroy()
    {
        try
        {

        }
        catch (System.Exception e)
        {

            throw e;
        }
    }
}
