using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Destroy : MonoBehaviour
{
    public GameObject destroyedVersion;
   
    void Start()
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}