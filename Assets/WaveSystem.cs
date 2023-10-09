using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WaveSystem : MonoBehaviour
{
    public GameObject enemy;
    public int xPos;
    public int zPos;

    public GameSystem gameSystem;
    public GameObject player;

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

    public void ActiveWave(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(EnemyDrop());
        }
    }

    IEnumerator EnemyDrop()
    {
        while (gameSystem.stormIsActive == true)
        {
            xPos = Random.Range(-20, 20);
            zPos = Random.Range(-20, 20);
            Instantiate (enemy, new Vector3((player.transform.position.x + xPos),player.transform.position.y, player.transform.position.z + zPos), Quaternion.identity);
            yield return new WaitForSeconds(3);
        }
    }
}
