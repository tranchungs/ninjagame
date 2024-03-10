using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    
    private GameInputs gameInputs;
    private Vector2 vector2Input; 
    private void Awake()
    {
        gameInputs = new GameInputs();
        gameInputs.Player.Enable();
    }

    void Start()
    {
  
       

       
    }

    
    void Update()
    {
        vector2Input = gameInputs.Player.Move.ReadValue<Vector2>();
    }
    public Vector2 GetVectoInput()
    {
        return vector2Input.normalized;
    }

}
