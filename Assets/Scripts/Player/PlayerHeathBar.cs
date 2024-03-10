using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeathBar : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Image Hp_fill;
    [SerializeField] private TextMeshProUGUI Hp_text;
    [SerializeField] private Image Mp_fill;
    [SerializeField] private TextMeshProUGUI Mp_text;
    void Awake()
    {
        player.OnHeathBarChange += Player_OnHeathBarChange;
      
    }

    private void Player_OnHeathBarChange(object sender, Player.OnHeathBarChangeArgs e)
    {
        SetHeathBar(e.playerSO);
    }



    // Update is called once per frame
    void Update()
    {
      
    }
 
    private void SetHeathBar(PlayerSO player)
    {
        Hp_text.SetText(player.current_HP.ToString());
        float Hp_fillAmount = (float)(player.current_HP / player.MaxHP);
        Debug.Log(Hp_fillAmount);
        Hp_fill.fillAmount = Hp_fillAmount;

        Mp_text.SetText(player.current_MP.ToString());
        float Mp_fillAmount = (float)(player.current_MP / player.MaxMP);
        Debug.Log(Mp_fillAmount);
        Mp_fill.fillAmount = Mp_fillAmount;
    }
}
