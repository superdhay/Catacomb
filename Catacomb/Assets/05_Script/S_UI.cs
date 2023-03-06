using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_UI : MonoBehaviour
{
    GameObject Life1;
    GameObject Life2;
    GameObject Life3;

    // Start is called before the first frame update
    void Start()
    {
        Life1 = GameObject.Find("Life1");
        Life2 = GameObject.Find("Life2");
        Life3 = GameObject.Find("Life3");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.PV == 3)
        {
            Life1.GetComponent<Image>().color = Color.white;
            Life2.GetComponent<Image>().color = Color.white;
            Life3.GetComponent<Image>().color = Color.white;
        }
        else if (GameManager.PV == 2)
        {
            Life1.GetComponent<Image>().color = Color.white;
            Life2.GetComponent<Image>().color = Color.white;
            Life3.GetComponent<Image>().color = Color.black;
        }
        else if (GameManager.PV == 1)
        {
            Life1.GetComponent<Image>().color = Color.white;
            Life2.GetComponent<Image>().color = Color.black;
            Life3.GetComponent<Image>().color = Color.black;
        }
        else
        {
            Life1.GetComponent<Image>().color = Color.black;
            Life2.GetComponent<Image>().color = Color.black;
            Life3.GetComponent<Image>().color = Color.black;
        }
    }
}
