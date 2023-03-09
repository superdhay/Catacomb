using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DestroyWithDelay : MonoBehaviour
{

    public float DestructionTimer;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestructionTimer);
    }

}
