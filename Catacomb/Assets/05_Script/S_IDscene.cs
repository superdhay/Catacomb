using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_IDscene : MonoBehaviour
{
    public int ID;

    private void Awake()
    {
        GameManager.ID = ID;
    }
}
