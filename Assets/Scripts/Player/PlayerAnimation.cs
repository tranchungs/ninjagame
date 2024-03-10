using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Player player;
    private PlayerActions actions;
    private Animator animator;
    private Vector2 info;
    private bool isJumping;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();

    }
  
    void Start()
    {
        player.OnPlayerActionChange += Player_OnPlayerActionChange;
        player.OnEquipWeapon += Player_OnEquipWeapon;
        player.OnAttack += Player_OnAttack;
    }

    private void Player_OnAttack(object sender, System.EventArgs e)
    {
        animator.SetTrigger("isAttack");
    }

    private void Player_OnEquipWeapon(object sender, Player.OnEquipWeaponArgs e)
    {
        setAnimationEquipWeapon(e.weapon);
    }

    private void Player_OnPlayerActionChange(object sender, Player.OnPlayerActionChangeArgs e)
    {
        actions = e.Actions;
        info = e.info;
        isJumping = e.isJumping;
    }

    // Update is called once per frame
    void Update()
    {
        setAnimation();
    }
    private void setAnimation()
    {
        switch (actions)
        {
            case PlayerActions.MOVE_NO_WEAPON:
                animator.SetBool("isJumping", isJumping);
                animator.SetFloat("moveSpeed", Mathf.Abs(info.x));
                break;
        
        }
    }
    private void setAnimationEquipWeapon(WeaponSO weapon)
    {
        switch (weapon.name)
        {
            case "Sword":
                animator.SetBool("isSword", true);
                animator.SetBool("isBow", false);
                animator.SetBool("isSpear", false);
            break;
            case "Bow":
                animator.SetBool("isSword", false);
                animator.SetBool("isBow", true);
                animator.SetBool("isSpear", false);
                break;
            case "Spear":
                animator.SetBool("isSword", false);
                animator.SetBool("isBow", false);
                animator.SetBool("isSpear", true);
                break;
        }
     
    }
}
