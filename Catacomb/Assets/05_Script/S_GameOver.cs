using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S_GameOver : MonoBehaviour
{
    public Button RetryBoutton, ExitBoutton;

    
    void Start()
    {
        RetryBoutton.GetComponent<Button>().onClick.AddListener(Retry); //AddListener permet de donner l'info qu'il faut que le boutton s'active si on clique dessus
        ExitBoutton.GetComponent<Button>().onClick.AddListener(Exit);
    }

    void Retry()
    {
        GameManager.PV = 3;
        GameManager.Orbes = 0;
        GameManager.Flag_Dead = false;
        GameManager.Flag_Void = false;
        SceneManager.LoadScene(1);
    }

    void Exit()
    {
        GameManager.PV = 3;
        GameManager.Orbes = 0;
        GameManager.Flag_Key = false;
        GameManager.Flag_Cranck = false;
        GameManager.Flag_TrapDoor = false;
        GameManager.Flag_Dead = false;
        GameManager.Flag_Void = false;
        GameManager.Checkpoint = 0;
        SceneManager.LoadScene(0);
    }

}
