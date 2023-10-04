using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject Target = null;
    public GameObject T = null;
    public float speed;
    public bool isExploring = true;

    public PlayerStates playerStates;
    void Start()
    {
        playerStates.GetComponent<PlayerStates>();

        Target = GameObject.FindGameObjectWithTag("Player");
        T = GameObject.FindGameObjectWithTag("Target");
    }

    void Update()

    {
        // Ce qui permet de faire en sorte que la caméra suive le joueur avec une sorte d'offset
            this.transform.LookAt(Target.transform);
            float carMove = Mathf.Abs(Vector3.Distance(this.transform.position, T.transform.position) * speed);
            this.transform.position = Vector3.MoveTowards(this.transform.position, T.transform.position, carMove * Time.deltaTime);

    }

    public void CameraForExploring()
    {

    }

    public void CameraForFighting()
    {
        // Met la caméra dans une position au dessus de la carte pour la phase de combat.
            this.transform.LookAt(Target.transform);
            T.transform.position = new Vector3(this.transform.position.x, 50, this.transform.position.z);
            return;
    }
}
