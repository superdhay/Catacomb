using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_StatueLumineuse : MonoBehaviour
{
    private int CoutOrbes = 5;

    private GameObject Player;
    public GameObject OrbeLumineuse;

    public GameObject ValeurOrbes;

    public bool Flag_UseStatue;

    private void Start()
    {

        Player = GameObject.FindGameObjectWithTag("Player");

        ValeurOrbes = GameObject.Find("QuantitéOrbes");
        ValeurOrbes.GetComponent<Text>().text = GameManager.Orbes.ToString();
        OrbeLumineuse.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" )
        {

            Debug.Log("Interaction Statue");

            if (GameManager.Orbes >= CoutOrbes)
            {

                Flag_UseStatue = true;

            }
            else Flag_UseStatue = false;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Flag_UseStatue = false;
        }
    }

    public void Update()
    {
        if (GameManager.Flag_Statue_On && Flag_UseStatue)
        {
            Debug.Log("Depense = true");
            GameManager.Orbes = GameManager.Orbes - CoutOrbes;
            ValeurOrbes.GetComponent<Text>().text = GameManager.Orbes.ToString();
            gameObject.GetComponent<S_StatueLumineuse>().enabled = false;
            OrbeLumineuse.SetActive(true);
        }
    }

}
