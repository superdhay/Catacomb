using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/* Quand on est dans la collision du bougeoire, si on a assez d'orbe, on dépense le nombre d'orbe requis et on allume ce bougeoire. 
 * Quand un bougeoire s'allume, les autres bougeoire s'éteignent. 
 * Quand le bougeoire s'allume, il créé un nouveau point de spawn pour le Player et sauvegarde la progression.
 * S'il est allumé, on ne peux pas re-depenser ses orbes.
 * 
 * Idee: Quand une bougeoir est allumé le script est désactivé, et il active le script des autres bougeoire.
 */

public class S_Bouguoir : MonoBehaviour
{
    private int CoutOrbesBougies = 1;

    public GameObject Player;
    public GameObject Flammes;

    public GameObject ValeurOrbes;
    public GameObject Bougie1;
    public GameObject Bougie2;

    public bool Flag_UseBougie;

    private void Start()
    {

        Player = GameObject.FindGameObjectWithTag("Player");

        ValeurOrbes = GameObject.Find("QuantitéOrbes");
        ValeurOrbes.GetComponent<Text>().text = GameManager.Orbes.ToString();
        Flammes.SetActive(false);
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {


            if (GameManager.Orbes >= CoutOrbesBougies)
            {

                Flag_UseBougie = true;

            }
            else Flag_UseBougie = false;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Flag_UseBougie = false;
        }
    }

    public void Update()
    {
        if (GameManager.Flag_Statue_On && Flag_UseBougie)
        {


            Bougie1.GetComponent<S_Bouguoir>().enabled = true;
            Bougie1.GetComponent<S_Bouguoir>().Flammes.SetActive(false);
            Bougie2.GetComponent<S_Bouguoir>().enabled = true;
            Bougie2.GetComponent<S_Bouguoir>().Flammes.SetActive(false);


            GameManager.Orbes = GameManager.Orbes - CoutOrbesBougies;
            ValeurOrbes.GetComponent<Text>().text = GameManager.Orbes.ToString();
            gameObject.GetComponent<S_Bouguoir>().enabled = false;
            Flammes.SetActive(true);


        }
    }



}
