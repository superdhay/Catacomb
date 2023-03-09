using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Void : MonoBehaviour
{
    public GameObject LBoy;
    public GameObject Respawn;
    public GameObject FadeIn;
    public GameObject FadeOut;

    public float Timer;

    void Start()
    {
        LBoy = GameObject.FindGameObjectWithTag("Player");
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer >= 0.1f && Timer <=3) FadeIn.SetActive(true);

        if (Timer >= 3 && Timer <= 5)
        {
            FadeOut.SetActive(true);
            FadeIn.SetActive(false);
            Debug.Log("LBoy is dead by void");
            LBoy.transform.position = Respawn.transform.position;
            GameManager.PV = GameManager.PV - 1;
            Timer = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            FadeIn.SetActive(false);
            FadeOut.SetActive(false);
            Timer = Timer + Time.deltaTime;
        }
    }
}
