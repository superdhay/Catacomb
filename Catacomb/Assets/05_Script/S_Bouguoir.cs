using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/* Quand on est dans la collision du bougeoire, si on a assez d'orbe, on dépense le nombre d'orbe requis et on allume ce bougeoire. 
 * Quand un bougeoire s'allume, les autres bougeoire s'éteignent. 
 * Quand le bougeoire s'allume, il créé un nouveau point de spawn pour le Player et sauvegarde la progression.
 * S'il est allumé, on ne peux pas re-depenser ses orbes.
 */

public class S_Bouguoir : MonoBehaviour
{
    private int CoutOrbesBougies = 1;

    private GameObject Player;
    //public GameObject Bougeoire;

    public GameObject ValeurOrbes;

    public bool Flag_On;

    private void Start()
    {

        Player = GameObject.FindGameObjectWithTag("Player");


        ValeurOrbes = GameObject.Find("QuantitéOrbes");
        ValeurOrbes.GetComponent<Text>().text = GameManager.Orbes.ToString();

        Flag_On = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            Debug.Log("Interaction Bougeoire");

            if (GameManager.Orbes >= CoutOrbesBougies)
            {

                GameManager.Flag_Bougeoir_On = true;

            }
            else GameManager.Flag_Bougeoir_On = false;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Flag_Bougeoir_On = false;
        }
    }

    public void Update()
    {
        if (Player.GetComponent<S_PlayerControler>().Flag_DepenseBougie == true)
        {
            Debug.Log("Depense = true");
            GameManager.Orbes = GameManager.Orbes - CoutOrbesBougies;
            ValeurOrbes.GetComponent<Text>().text = GameManager.Orbes.ToString();
            Flag_On = true;
        }

        if (Flag_On == true)
        {
            GameManager.Flag_Bougeoir_On = false;
            Player.GetComponent<S_PlayerControler>().Flag_DepenseBougie = false;

            Flag_On = false; // Si true, on ne peut plus dépenser d'orbes, même si on en a assez
        }

    }

}
