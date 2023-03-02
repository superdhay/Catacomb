using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Camera : MonoBehaviour
{
    GameObject TargetPerso;


    void Awake()
    {
        TargetPerso = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = new Vector3 (TargetPerso.transform.position.x,(TargetPerso.transform.position.y + 0.72f), -7.44f);

    }
}
