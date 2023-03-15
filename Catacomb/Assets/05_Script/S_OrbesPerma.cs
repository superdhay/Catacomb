using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_OrbesPerma : MonoBehaviour
{
    private int QuantiteOrbe = 5;

    public GameObject FX;
    public GameObject ValeurOrbes;
    public GameObject orbe;

    private bool Flag_Respawn;

    private float CompteurRespawn;
    public float DureeDeRespawn;

    void Start()
    {
        ValeurOrbes = GameObject.Find("QuantitéOrbes");
        ValeurOrbes.GetComponent<Text>().text = GameManager.Orbes.ToString();
        CompteurRespawn = 0;
        Flag_Respawn = false;
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Flag_Respawn == false)
        {

            Instantiate(FX, transform.position, Quaternion.identity);
            GameManager.Orbes = GameManager.Orbes + QuantiteOrbe;
            ValeurOrbes.GetComponent<Text>().text = GameManager.Orbes.ToString();

            Flag_Respawn = true;
            orbe.SetActive(false);

        }

    }

    private void Update()
    {
        if (Flag_Respawn == true)
        {
            CompteurRespawn = CompteurRespawn + Time.deltaTime;
        }

        if (CompteurRespawn >= DureeDeRespawn)
        {
            CompteurRespawn = 0;
            orbe.SetActive(true);
            Flag_Respawn = false;
        }

    }

}
