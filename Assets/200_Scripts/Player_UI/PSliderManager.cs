using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PSliderManager : MonoBehaviour
{
    public Stats stats;
    public Slider hpSlider;

    void Start()
    {
        stats = GetComponent<Stats>();
        hpSlider.maxValue = stats.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = stats.currentHealth;
    }
}
