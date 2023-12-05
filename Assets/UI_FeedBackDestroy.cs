using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_FeedBackDestroy : MonoBehaviour
{
    public float timeBeforeDestroy = 5;

    public void Start()
    {
        
    }
    public void Update()
    {
        timeBeforeDestroy -= Time.deltaTime;

        if (timeBeforeDestroy < 0)
        {
            Destroy(gameObject);
        }
    }
}
