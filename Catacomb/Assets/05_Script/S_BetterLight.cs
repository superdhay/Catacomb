using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BetterLight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Flag_Statue1)
        {
            transform.rotation = Quaternion.Euler(-50, -18, 0);
            gameObject.GetComponent<Light>().colorTemperature = Mathf.Lerp(gameObject.GetComponent<Light>().colorTemperature, 7500, 0.05f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(-72.9f, -7.8f, 0);
            gameObject.GetComponent<Light>().colorTemperature = Mathf.Lerp(gameObject.GetComponent<Light>().colorTemperature, 20000, 0.05f);
        }
    }
}
