using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Intro : MonoBehaviour
{
    float Timer;

    void Start()
    {
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Timer = Timer + Time.deltaTime;

        if (Timer >= 12) SceneManager.LoadScene(1);
    }
}
