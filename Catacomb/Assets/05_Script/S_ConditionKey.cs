using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ConditionKey : MonoBehaviour
{
    public GameObject True, False;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Flag_Key || GameManager.Flag_KeyUsed)
        {
            False.SetActive(false);
            True.SetActive(true);
        }
        else
        {
            True.SetActive(false);
            False.SetActive(true);
        }
    }
}
