using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnnemyDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LBoyAttack") 
        {
            
        }

    }
}
