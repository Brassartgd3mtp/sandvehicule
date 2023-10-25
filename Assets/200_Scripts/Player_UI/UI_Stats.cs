using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Stats : MonoBehaviour
{
    [SerializeField] private Stats stats;

    [SerializeField] private TMP_Text maxHP;
    [SerializeField] private TMP_Text Damage;
    [SerializeField] private TMP_Text AttackSpeed;
    [SerializeField] private TMP_Text Speed;

    void Start()
    {
        StatsUpdate();
    }


    void Update()
    {
        
    }

    public void StatsUpdate() // permet de récupérer les stats du Player pour actualiser les statistiques sur l'UI
    {
        maxHP.text = stats.maxHealth.ToString();
        Damage.text = stats.damage.ToString();
        AttackSpeed.text = stats.attackSpeed.ToString();
        Speed.text = stats.maxSpeed.ToString();
    }

}
