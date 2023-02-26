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

                GameManager.Flag_Statue_On = true;

            }
            else GameManager.Flag_Statue_On = false;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Flag_Statue_On = false;
        }
    }

    public void Update()
    {
        if (Player.GetComponent<S_PlayerControler>().Flag_DepenseStatue == true)
        {
            Debug.Log("Depense = true");
            GameManager.Orbes = GameManager.Orbes - CoutOrbes;
            ValeurOrbes.GetComponent<Text>().text = GameManager.Orbes.ToString();
            gameObject.GetComponent<S_StatueLumineuse>().enabled = false;
            OrbeLumineuse.SetActive(true);
        }
    }

}
