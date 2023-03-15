using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ConditionCranck : MonoBehaviour
{

    public GameObject True, False;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Flag_Cranck)
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
