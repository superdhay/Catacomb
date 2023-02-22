using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_StatueLumineuse : MonoBehaviour
{
    public int CoutOrbes;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && Input.GetAxis("Fire1") >= 0.9f && GameManager.Orbes >= CoutOrbes)
        {

            GameManager.Orbes = GameManager.Orbes - CoutOrbes;
            gameObject.GetComponent<S_StatueLumineuse>().enabled = false;

        }
    }

}
