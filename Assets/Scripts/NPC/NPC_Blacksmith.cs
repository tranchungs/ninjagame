using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Blacksmith : NPC
{

    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Interact(Player player)
    {
        Debug.Log("I'm NPC_Blacksmith");
   
    }
  
}
