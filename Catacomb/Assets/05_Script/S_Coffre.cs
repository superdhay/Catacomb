using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_Coffre : MonoBehaviour
{
    GameObject Icon;
    public GameObject animatedPart;


    void Awake()
    {
        Icon = GameObject.Find("Manivelle");
        Icon.SetActive(false);

        animatedPart.GetComponent<Animator>().enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animatedPart.GetComponent<Animator>().enabled = true;
            Icon.SetActive(true);
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
