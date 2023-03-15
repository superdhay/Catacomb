using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_ToBeContinued : MonoBehaviour
{

    float Timer;

    void Start()
    {
        Timer = 0;

        GameManager.PV = 3;
        GameManager.Orbes = 0;
        GameManager.Flag_Key = false;
        GameManager.Flag_Cranck = false;
        GameManager.Flag_TrapDoor = false;
        GameManager.Flag_Dead = false;
        GameManager.Flag_Void = false;
        GameManager.Checkpoint = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Timer = Timer + Time.deltaTime;

        if (Timer >= 10) SceneManager.LoadScene(0);

    }
}
