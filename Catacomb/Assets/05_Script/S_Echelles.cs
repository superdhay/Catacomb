using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Echelles : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Flag_ProtectionClimb) gameObject.GetComponent<Collider>().enabled = true;
        else gameObject.GetComponent<Collider>().enabled = false;
    }
}
