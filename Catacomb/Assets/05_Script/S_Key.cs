using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Key : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Flag_Key = true;
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (GameManager.Flag_Key) Destroy(gameObject);       
    }
}
