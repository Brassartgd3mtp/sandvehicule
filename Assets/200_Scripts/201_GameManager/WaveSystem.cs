using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WaveSystem : MonoBehaviour
{
    public UnityEngine.GameObject enemy;
    public GameSystem gameSystem;
    public UnityEngine.GameObject player;
    public int enemyCount;

    public float Radius;

    public void Awake()
    {
        gameSystem = GetComponent<GameSystem>();
        player = UnityEngine.GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        
    }


    void FixedUpdate()
    {

    }



    public IEnumerator EnemyDrop() // 
    {
        while (gameSystem.stormIsActive == true)
        {
            float angle = Random.Range(0, 360);
            float x = Mathf.Cos(angle) * Radius;
            float z = Mathf.Sin(angle) * Radius;
            Vector3 pos = player.transform.position + new Vector3(x, 0, z);
            float angleDegrees = -angle * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
            Instantiate(enemy, pos, rot);
            enemyCount++;
            yield return new WaitForSeconds(3);
        }
    }
}
