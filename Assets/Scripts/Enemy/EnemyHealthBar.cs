using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    private Enemy enemy;

    [SerializeField] private Image fillBar;
    [SerializeField] private TextMeshProUGUI textMeshDameTake;
    // Start is called before the first frame update
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }
    void Start()
    {
        enemy.OnTakeDameHealthBar += Enemy_OnTakeDameHealthBar;
    }

    private void Enemy_OnTakeDameHealthBar(object sender, Enemy.OnTakeDameHealthBarArg e)
    {
        SetFillBar(e.health_normalrize);
    }

    private void SetFillBar(float normalrize)
    {
        fillBar.fillAmount=normalrize;  
    }
}
