using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/EnemyBase")]

public class EnemyData : ScriptableObject
{

    public float health = 10;
    public float speed = 1.5f;
    public int damage;
    public float attackSpeed;
    public UnityEngine.GameObject player;

}
