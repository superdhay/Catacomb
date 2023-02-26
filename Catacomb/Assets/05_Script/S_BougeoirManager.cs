using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BougeoirManager : MonoBehaviour
{
    public GameObject Bougie1, Bougie2, Bougie3;

    // Start is called before the first frame update
    void Start()
    {
        Bougie1.GetComponent<S_Bouguoir>();
        Bougie2.GetComponent<S_Bouguoir>();
        Bougie3.GetComponent<S_Bouguoir>();
    } /*

    // Update is called once per frame
    void Update()
    {
        if (Bougie1.GetComponent<S_Bouguoir>().Flag_On == true)
        {
            Bougie2.GetComponent<S_Bouguoir>().Flag_On = false;
            Bougie3.GetComponent<S_Bouguoir>().Flag_On = false;
        }

        else if (Bougie2.GetComponent<S_Bouguoir>().Flag_On == true)
        {
            Bougie1.GetComponent<S_Bouguoir>().Flag_On = false;
            Bougie3.GetComponent<S_Bouguoir>().Flag_On = false;
        }

        else if (Bougie3.GetComponent<S_Bouguoir>().Flag_On == true)
        {
            Bougie2.GetComponent<S_Bouguoir>().Flag_On = false;
            Bougie1.GetComponent<S_Bouguoir>().Flag_On = false;
        }

    } */
}
