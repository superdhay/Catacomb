using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Void : MonoBehaviour
{
    public GameObject LBoy;
    public GameObject Respawn;

    public float Timer;

    bool Void = false;

    void Start()
    {
        LBoy = GameObject.FindGameObjectWithTag("Player");
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Void) Timer = Timer + Time.deltaTime;

        if (Timer >= 1 && Timer <= 5)
        {
            Debug.Log("LBoy is dead by void");
            GameManager.PV = GameManager.PV - 3;
            Timer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Flag_Void = true;
            Void = true;
        }

    }

}
