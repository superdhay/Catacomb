using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SavElement : MonoBehaviour
{
    private void Awake()
    {

        if (FindObjectsOfType(GetType()).Length > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);

    }

}
