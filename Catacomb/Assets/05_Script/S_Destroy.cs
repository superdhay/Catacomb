using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Destroy : MonoBehaviour
{
    public GameObject destroyedVersion;
    // Start is called before the first frame update
    void onMouseDown()
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}