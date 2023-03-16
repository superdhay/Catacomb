using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CranckEvent : MonoBehaviour
{

    public GameObject NewEnnemy;


    void Start()
    {
        if (GameManager.Flag_Cranck) NewEnnemy.SetActive(true);
        else NewEnnemy.SetActive(false);
    }
}
