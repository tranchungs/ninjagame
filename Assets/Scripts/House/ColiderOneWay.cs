using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderOneWay : MonoBehaviour
{
    [SerializeField] private Player player;
    private void Awake()
    {
        player.OnPlayerActionChange += Player_OnPlayerActionChange;
    }

    private void Player_OnPlayerActionChange(object sender, Player.OnPlayerActionChangeArgs e)
    {
        SetTriger(e.isJumping);
    }
    private void SetTriger(bool jump)
    {
        GetComponent<BoxCollider2D>().isTrigger = jump;
    }
}
