using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_IDscene : MonoBehaviour
{
    public int ID;
    GameObject Musique;


    private void Awake()
    {
        Musique = GameObject.Find("Catacombs");
    }


    void Start()
    { 
        if (ID == 1 || ID == 2) Musique.GetComponent<AudioSource>().enabled = true;
        else Musique.GetComponent<AudioSource>().enabled = true;
    }
}
