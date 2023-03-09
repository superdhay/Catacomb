using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DestructibleRocks : MonoBehaviour
{

    public GameObject Fissure1;
    public GameObject Fissure2;
    public GameObject Fissure3;
    public GameObject Fissure4;

    GameObject Player;

    public bool Flag_Destroy = false;

    public bool canDig = false;

    // Start is called before the first frame update
    void Start()
    {

        Player = GameObject.FindGameObjectWithTag("Player");

        GetComponent<S_Destroy>().enabled = false;

        Fissure1.GetComponent<Rigidbody>().isKinematic = true;
        Fissure2.GetComponent<Rigidbody>().isKinematic = true;
        Fissure3.GetComponent<Rigidbody>().isKinematic = true;
        Fissure4.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.Flag_Dig == true && canDig == true)
        {
            Flag_Destroy = true;
        }

        if (Flag_Destroy)
        {
            Player.GetComponent<Animator>().SetTrigger("Dig");

            GetComponent<S_Destroy>().enabled = true;

            Fissure1.GetComponent<Rigidbody>().isKinematic = false;
            Fissure2.GetComponent<Rigidbody>().isKinematic = false;
            Fissure3.GetComponent<Rigidbody>().isKinematic = false;
            Fissure4.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player") canDig = true;

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") canDig = false;
    }
}
