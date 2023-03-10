using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Void : MonoBehaviour
{
    public GameObject LBoy;
    public GameObject Respawn;
    public GameObject Fade;

    public float Timer;

    void Start()
    {
        LBoy = GameObject.FindGameObjectWithTag("Player");
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Timer >= 1 && Timer <= 5)
        {
            Debug.Log("LBoy is dead by void");
            LBoy.transform.position = Respawn.transform.position;
            GameManager.PV = GameManager.PV - 1;
            Timer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Fade.SetActive(true);
        Fade.GetComponent<Animator>().SetTrigger("Play");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Timer = Timer + Time.deltaTime;
        }
    }
}
