using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_ShowItem : MonoBehaviour
{
    public Image Key;
    public Image Cranck;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Flag_Key && !GameManager.Flag_KeyUsed) Key.color = new Color(1, 1, 1, 1);
        else Key.color = new Color(0, 0, 0, 0);

        if (GameManager.Flag_Cranck) Cranck.color = new Color(1, 1, 1, 1);
        else Cranck.color = new Color(0, 0, 0, 0);
    }
}
