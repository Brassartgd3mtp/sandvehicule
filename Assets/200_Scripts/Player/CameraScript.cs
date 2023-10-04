using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject Target = null;
    public GameObject T = null;
    public float speed;

    public PlayerStates playerStates;
    void Start()
    {
        playerStates.GetComponent<PlayerStates>();

        Target = GameObject.FindGameObjectWithTag("Player");
        T = GameObject.FindGameObjectWithTag("Target");
    }

    void Update()

    {
        ChangeCameraForExploring();
    }

    public void ChangeCameraForExploring()
    {
        do
        {
            this.transform.LookAt(Target.transform);
            float carMove = Mathf.Abs(Vector3.Distance(this.transform.position, T.transform.position) * speed);
            this.transform.position = Vector3.MoveTowards(this.transform.position, T.transform.position, carMove * Time.deltaTime);
        } while (playerStates.states == PlayerStates.States.Exploring);
    }

    public void ChangeCameraForFighting()
    {
            this.transform.LookAt(Target.transform);
            T.transform.position = new Vector3(this.transform.position.x, 50, this.transform.position.z);
            return;
    }
}
