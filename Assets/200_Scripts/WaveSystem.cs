using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WaveSystem : MonoBehaviour
{
    public GameObject enemy;
    
    public int xPos1, xPos2;
    public int zPos1, zPos2;
    public int randomX, randomZ;
    public float valueForRandomX, valueForRandomZ;
    public GameSystem gameSystem;
    public GameObject player;
    public int enemyCount;

    public void Awake()
    {
        gameSystem = GetComponent<GameSystem>();
        player = GameObject.FindGameObjectWithTag("Player");
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
            // Récupère des random pour X et Z pour le swpan du prochain ennemi, et cela toutes les 3 secondes
            xPos1 = Random.Range(15, 25);
            xPos2 = Random.Range(-25, -15);
            valueForRandomX = Random.Range(0f, 1f);
            if (valueForRandomX >= 0.5)
            {
                randomX = xPos1;
            } else if (valueForRandomX < 0.5) { randomX = xPos2; }

            zPos1 = Random.Range(15, 25);
            zPos2 = Random.Range(-25, -15);
            valueForRandomZ = Random.Range(0f,1f);
            if (valueForRandomZ >= 0.5)
            {
                randomZ = zPos1;
            } else if (valueForRandomZ < 0.5) { randomZ = zPos2; } 

            Instantiate (enemy, new Vector3((player.transform.position.x + randomX),1, player.transform.position.z + randomZ), Quaternion.identity);
            enemyCount++;
            yield return new WaitForSeconds(3);
        }
    }
}
