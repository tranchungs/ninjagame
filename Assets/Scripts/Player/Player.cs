using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class Player : MonoBehaviour
{

    [SerializeField] private PlayerSO player;
    public event EventHandler<OnPlayerActionChangeArgs> OnPlayerActionChange;
    public class OnPlayerActionChangeArgs : EventArgs
    {
        public PlayerActions Actions;
        public Vector2 info;
        public bool isJumping;
    }
    public event EventHandler<OnEquipWeaponArgs> OnEquipWeapon;

    public class OnEquipWeaponArgs : EventArgs
    {
        public WeaponSO weapon;
    }
    public event EventHandler OnAttack;

    public event EventHandler<OnHeathBarChangeArgs> OnHeathBarChange;
    public class OnHeathBarChangeArgs : EventArgs
    {
        public PlayerSO  playerSO;
    }
    [SerializeField] private PlayerInput gameInputs;
    [SerializeField] private CharacterController2D controller2D;
    [SerializeField] private float moveSpeed;
    private Vector2 movement;
    private bool jump;
    private bool isAttack;
    private WeaponSO currentWeapon;
    public float attackRange = 1f;
    [SerializeField] private LayerMask layerCollider;

    [SerializeField] public List<ItemSO> listItemBackPack;
    private void Awake()
    {
        
        jump = true;
   
    }
    void Start()
    {
        OnHeathBarChange?.Invoke(this, new OnHeathBarChangeArgs { playerSO = player });
    }

    // Update is called once per frame
    void Update()
    {
        movement = gameInputs.GetVectoInput();
        isAttack = false;
       
    }
    private void FixedUpdate()
    {
        HandleMovement();
    }
   

    private void HandleMovement()
    { 
        if (movement.y > 0.4)
        {
            jump = true;    
        }
        OnPlayerActionChange?.Invoke(this, new OnPlayerActionChangeArgs { Actions = PlayerActions.MOVE_NO_WEAPON, info = movement, isJumping =jump });
        controller2D.Move(movement.x * moveSpeed * Time.fixedDeltaTime, false, jump, movement.y);
        jump = false;
       
    }
    public List<ItemSO> GetListItemBackPack()
    {
        return listItemBackPack;
    }
    public void SetWeapon(WeaponSO weapon)
    {
        this.currentWeapon = weapon;
        OnEquipWeapon?.Invoke(this, new OnEquipWeaponArgs { weapon = this.currentWeapon });
    }
    public void UsePotion(MedicineSO potion,int index)
    {
        switch(potion.typePotion)
        {
            case PotionType.HP:
               
                if ((player.current_HP + potion.effectValue) > player.MaxHP)
                {
                    player.current_HP = player.MaxHP;
                }
                else
                {
                    player.current_HP += potion.effectValue;
                }
                OnHeathBarChange?.Invoke(this, new OnHeathBarChangeArgs { playerSO = player });

                if (potion.amount == 1)
                {
                    Debug.Log(potion.amount);
                    listItemBackPack.Remove(potion);

                }
                else
                {
                    listItemBackPack[index].amount -= 1;
                }
                break;
            case PotionType.MP:
                if ((player.current_MP + potion.effectValue) > player.MaxMP)
                {
                    player.current_MP = player.MaxMP;
                }
                else
                {
                    player.current_MP += potion.effectValue;
                }
                OnHeathBarChange?.Invoke(this, new OnHeathBarChangeArgs { playerSO = player });
                if (potion.amount == 1)
                {
                    listItemBackPack.Remove(potion);

                }
                else
                {
                    listItemBackPack[index].amount -= 1;
                }
                break;
        }
    }
    public void AttackAnimation()
    {
        Vector3 pos = transform.position;
        Collider2D colliderHit= Physics2D.OverlapCircle(pos, attackRange, layerCollider);
        if (colliderHit != null)
        {
            switch (colliderHit.tag)
            {
                case "Enemy":
                    if (currentWeapon != null)
                    {
                        OnAttack?.Invoke(this, EventArgs.Empty);
                        colliderHit.GetComponent<Enemy>().OnTakeDame(40);
                    }
                    break;
                case "NPC":
                    colliderHit.GetComponent<NPC>().Interact(this);
                    break;
            }
            
         
        }

        
    }
    public void Attack()
    {
        Debug.Log("Attack");
        
    }
    public void Buy(ItemSO item)
    {
        switch (item.type)
        {
            case ItemType.WEAPON:
                for (int i = 0; i < listItemBackPack.Count; i++)
                {
                    if (listItemBackPack[i] == item)
                    {
                        //can't not buy 
                        Debug.Log("Equarl");
                    }
                    else
                    {

                        listItemBackPack.Add(item);

                    }
                } 
                break;
            case ItemType.MEDICINE:
                bool isHave = false;
                int index = 0;
                for (int i = 0; i < listItemBackPack.Count; i++)
                {
                    if (listItemBackPack[i] == item)
                    {
                        isHave = true;
                        index = i;
                        break;
                    }
               
                }
                if (isHave)
                {
                    listItemBackPack[index].amount += 1;
                }
                else
                {
                    listItemBackPack.Add(item);
                }
                break;
            case ItemType.FOOD:
                break;
            default:
                break;
        }


    }
    
}

public enum PlayerActions
{
    MOVE_NO_WEAPON,
    MOVE_SWORD,
    ATTACK_SWORD,
    IDLE,
    RUN,
    JUMP,
    ATTACK,
    ROLL,
    CLIMB,
    DIE,

}