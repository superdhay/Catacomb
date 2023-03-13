using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Plateforme : MonoBehaviour
{
    GameObject LBoy;

    private void Start()
    {
        LBoy = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") LBoy.transform.parent = gameObject.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") LBoy.transform.parent = null;
    }
}
