using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Void : MonoBehaviour
{
    public GameObject LBoy;
    public GameObject Respawn;

    void Start()
    {
        LBoy = GameObject.FindGameObjectWithTag("Player");   
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("LBoy is dead by void");
            LBoy.transform.position = Respawn.transform.position;
        }
    }
}
