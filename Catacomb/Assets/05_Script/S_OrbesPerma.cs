using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_OrbesPerma : MonoBehaviour
{
    private int QuantiteOrbe = 5;

    public GameObject FX;
    public GameObject ValeurOrbes;
    private GameObject orbe;

    private bool Flag_Respawn;

    private float CompteurRespawn;
    public float DureeDeRespawn;

    void Start()
    {
        ValeurOrbes = GameObject.Find("Quantit�Orbes");
        ValeurOrbes.GetComponent<Text>().text = GameManager.Orbes.ToString();
        orbe = GameObject.Find("Visuel");
        CompteurRespawn = 0;
        Flag_Respawn = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (Flag_Respawn == false)
        {

            Debug.Log("Orbe touch�e");
            Instantiate(FX, this.transform.position, Quaternion.identity);
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

            if (CompteurRespawn >= DureeDeRespawn)
            {
                CompteurRespawn = 0;
                orbe.SetActive(true);
                Flag_Respawn = false;
            }

        }

    }

}