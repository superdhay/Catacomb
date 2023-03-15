using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BetterLightBis: MonoBehaviour
{

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Flag_Statue2)
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
