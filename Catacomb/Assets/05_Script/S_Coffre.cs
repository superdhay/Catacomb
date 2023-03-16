using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Coffre : MonoBehaviour
{
    public GameObject animatedPart;
    public GameObject FX;


    void Awake()
    {
        animatedPart.GetComponent<Animator>().enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(FX, transform.position, transform.rotation);
            animatedPart.GetComponent<Animator>().enabled = true;
            GameManager.Flag_Cranck = true;
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }

    private void Update()
    {
        if (GameManager.Flag_Cranck)
        {
            animatedPart.GetComponent<Animator>().enabled = true;
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
