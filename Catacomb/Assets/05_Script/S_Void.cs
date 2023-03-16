using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Void : MonoBehaviour
{
    public GameObject LBoy;


    void Start()
    {
        LBoy = GameObject.FindGameObjectWithTag("Player");
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Flag_Void = true;
            Debug.Log("LBoy is dead by void");
            GameManager.PV = GameManager.PV - 3;
        }

    }

}
