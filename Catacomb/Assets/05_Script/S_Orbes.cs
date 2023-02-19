using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_Orbes : MonoBehaviour
{
    /* On va demander au script que quand on touche le trigger de l'orbe, ajout de x unité à la variable Orbes, fait appaitre un fx lumineux
     * pour dire qu'on a bien touché l'orbe puis le GameObject se détruise. 
     * Il faudra que le script écrive bien le changement de valeur de Orbes dans l'UI fait à cet effet.*/

    public int QuantiteOrbe;

    public GameObject PrefabOrbe;
    public GameObject FX;
    public GameObject ValeurOrbes;

    void Start()
    {
        ValeurOrbes = GameObject.Find("QuantitéOrbes");
        ValeurOrbes.GetComponent<Text>().text = GameManager.Orbes.ToString();
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Orbe touchée");
        Instantiate(FX,this.transform.position,Quaternion.identity);
        GameManager.Orbes = GameManager.Orbes + QuantiteOrbe;
        ValeurOrbes.GetComponent<Text>().text = GameManager.Orbes.ToString();
        Destroy(PrefabOrbe);
    }

}
