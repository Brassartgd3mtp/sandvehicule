using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControl : MonoBehaviour
{
    public bool atRangeOfPlayer;

    public EnemyData enemyData;

    public Text enemyName;
    public UnityEngine.GameObject enemyModel;
    public float health = 10;
    public float speed = 1.5f;
    public int damage;
    public float attackSpeed;


    // Script qui load les stats de l'ennemi
    void Start()
    {
        if (enemyData == null)
        {
            LoadEnemy(enemyData);
        }
    }

    public void LoadEnemy(EnemyData _data)
    {
        health = _data.health;
        speed = _data.speed;
        damage = _data.damage;
        attackSpeed = _data.attackSpeed;
    }
}
