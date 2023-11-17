using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public int enemyCount;
    public float Radius;

    public bool stormIsActive;

    public float timerOfStorm;

    public Slider timerSlider;
    public float timeBeforeStorm;
    //public float sliderValue;

    [SerializeField] private float minTimerBeforeStorm, maxTimerBeforeStorm;
    [SerializeField] private float minTimerOfStorm, maxTimerOfStorm;

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        stormIsActive = false;
    }

    public void Update()
    {
        if (stormIsActive && enemyCount <= 0) // Si il n'y a pas de tempête le timer avant activation de la tempête continu
        {
            timeBeforeStorm -= Time.deltaTime;
        }

        timerSlider.value = timeBeforeStorm; // ce qui relie le slider au temps avant la tempête 

        if (timeBeforeStorm <= 0) // la tempête s'active
        {
            ActiveWave();
        }

        if (stormIsActive) // le Timer de la tempête débute
        {
            timerOfStorm -= Time.deltaTime;
        }
        
        if (timerOfStorm <= 0)
        {
            stormIsActive = false;
        }

        if (timerOfStorm < 0 && enemyCount <= 0)
        {
            EndWave();
        }
    }

    public void ActiveWave() // lance la vague d'ennemi à la fin du timer de "timeBeforeThe Storm"
    {
        stormIsActive = true;
        StartCoroutine("EnemyDrop");
        timeBeforeStorm = Random.Range(minTimerBeforeStorm, maxTimerBeforeStorm);
        timerSlider.maxValue = timeBeforeStorm;
    }

    public void EndWave() // Fin de la wave, reset les valeurs pour repartir en exploration
    {
        Debug.Log("EndWave");
        stormIsActive = false;
        timerOfStorm = Random.Range(minTimerOfStorm, maxTimerOfStorm);
    }

    public IEnumerator EnemyDrop() // Drop aléatoire des ennemis en cercle autour du player
    {
        while (stormIsActive)
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
