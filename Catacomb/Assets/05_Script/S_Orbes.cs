using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_Orbes : MonoBehaviour
{
    /* On va demander au script que quand on touche le trigger de l'orbe, ajout de x unit� � la variable Orbes, fait appaitre un fx lumineux
     * pour dire qu'on a bien touch� l'orbe puis le GameObject se d�truise. 
     * Il faudra que le script �crive bien le changement de valeur de Orbes dans l'UI fait � cet effet.*/

    public int QuantiteOrbe;

    public GameObject PrefabOrbe;
    public GameObject FX;
    public GameObject ValeurOrbes;

    void Start()
    {
        ValeurOrbes = GameObject.Find("Quantit�Orbes");
        ValeurOrbes.GetComponent<Text>().text = GameManager.Orbes.ToString();
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Orbe touch�e");
        Instantiate(FX,this.transform.position,Quaternion.identity);
        GameManager.Orbes = GameManager.Orbes + QuantiteOrbe;
        ValeurOrbes.GetComponent<Text>().text = GameManager.Orbes.ToString();
        Destroy(PrefabOrbe);
    }

}
