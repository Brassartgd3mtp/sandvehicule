using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    public WaveSystem waveSystem;

    public bool stormIsActive;

    public float timerOfStorm;

    public Slider timerSlider;
    public float timeBeforeStorm;
    public float sliderValue;

    [SerializeField] private float minTimerBeforeStorm, maxTimerBeforeStorm;
    [SerializeField] private float minTimerOfStorm, maxTimerOfStorm;


    //private bool stopTimer;

    void Start()
    {
        waveSystem = GetComponent<WaveSystem>();

        stormIsActive = false;
        //stopTimer = false;

        //timeBeforeStorm = 10;
        //timerOfStorm = 20;

        

    }
    void Update()
    {
        if (stormIsActive == false && waveSystem.enemyCount <=0) // Si il n'y a pas de temp�te le timer avant activation de la temp�te continu
        {
            timeBeforeStorm -= Time.deltaTime;
        }
        
        timerSlider.value = timeBeforeStorm;        // ce qui relie le slider au temps avant la temp�te 

        if (timeBeforeStorm <= 0) // la temp�te s'active
        {
            ActiveWave();
        }

        if (stormIsActive == true) // le Timer de la temp�te d�bute
        {
            timerOfStorm -= Time.deltaTime;
        }
        if (timerOfStorm <= 0)
        {
            stormIsActive = false;
        }

        if (timerOfStorm < 0 && waveSystem.enemyCount <= 0)
        {
            EndWave();
        }
        

    }

    public void ActiveWave() // lance la vague d'ennemi � la fin du timer de "timeBeforeThe Storm"
    {
        stormIsActive = true;
        waveSystem.StartCoroutine("EnemyDrop");
        timeBeforeStorm = Random.Range(minTimerBeforeStorm, maxTimerBeforeStorm);
        timerSlider.maxValue = timeBeforeStorm;
    }

    public void EndWave() // Fin de la wave, reset les valeurs pour repartir en exploration
    {
        Debug.Log("EndWave");
        stormIsActive = false;
        timerOfStorm = Random.Range(minTimerOfStorm, maxTimerOfStorm);
    }
}
