using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SecuriteX : MonoBehaviour
{
    GameObject Player;
    
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") Player.transform.position = new Vector3(0,Player.transform.position.y, Player.transform.position.z);
    }
}
