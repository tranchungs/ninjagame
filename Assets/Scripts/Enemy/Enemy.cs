using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public event EventHandler<OnTakeDameHealthBarArg> OnTakeDameHealthBar;
    public class OnTakeDameHealthBarArg : EventArgs
    {
        public float health_normalrize;
        public float dame;
    }

    public int max_health;
    public int current_health;
    private void Awake()
    {
        max_health = 1000;
        current_health = max_health;
    }
    public void OnTakeDame(int dame)
    {
        current_health -= dame;
        Debug.Log(current_health);
        OnTakeDameHealthBar?.Invoke(this, new OnTakeDameHealthBarArg { health_normalrize = (float)current_health / max_health,dame = dame });
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
