using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TrapDoor : MonoBehaviour
{

    void Start()
    {
        gameObject.GetComponent<Animator>().enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && GameManager.Flag_Use) GameManager.Flag_TrapDoor = true;
    }

    private void Update()
    {
        if (GameManager.Flag_TrapDoor)
        {
            gameObject.GetComponent<Animator>().enabled = true;
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }

}
