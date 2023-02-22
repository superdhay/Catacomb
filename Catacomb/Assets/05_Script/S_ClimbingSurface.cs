using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ClimbingSurface : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") GameManager.isClimbing = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") GameManager.isClimbing = false;
    }

}
