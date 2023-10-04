using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject Target = null;
    public GameObject T = null;
    public float speed;
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        T = GameObject.FindGameObjectWithTag("Target");
    }

    void FixedUpdate()
    {
        this.transform.LookAt(Target.transform);
        float carMove = Mathf.Abs(Vector3.Distance(this.transform.position, T.transform.position) * speed);
        this.transform.position = Vector3.MoveTowards(this.transform.position,T.transform.position, carMove * Time.deltaTime);   
    }
}
