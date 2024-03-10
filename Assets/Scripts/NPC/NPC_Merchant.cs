using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Merchant : NPC
{
    [SerializeField] private GameObject shop;
    [SerializeField]List<MedicineSO> mMedicines;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    public override void Interact(Player player)
    {
        Debug.Log("I'm NPC_Merchant");
        ShowShop();
        this.player = player;
    }

    public List<MedicineSO> GetListMedicines()
    {
        return this.mMedicines;
    }
    private void ShowShop()
    {
        shop.SetActive(true);
    }
    public Player GetPlayerInteract()
    {
        return this.player;
    }
}
