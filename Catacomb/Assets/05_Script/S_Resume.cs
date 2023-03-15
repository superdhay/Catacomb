using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class S_Resume : MonoBehaviour
{
    public Button ExitBoutton;
    public GameObject resume;


    void Start()
    {
        ExitBoutton.GetComponent<Button>().onClick.AddListener(Exit);
    }

    void Update()
    {

    }

    void Exit()
    {
        Time.timeScale = 1;
        GameManager.PV = 3;
        GameManager.Orbes = 0;
        GameManager.Flag_Key = false;
        GameManager.Flag_Cranck = false;
        GameManager.Flag_TrapDoor = false;
        GameManager.Flag_Dead = false;
        GameManager.Flag_Void = false;
        GameManager.Flag_Statue1 = false;
        GameManager.Flag_Statue2 = false;
        GameManager.Checkpoint = 0;
        SceneManager.LoadScene(0);
    }

}
