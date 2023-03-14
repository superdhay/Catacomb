using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S_SceneManager : MonoBehaviour
{
    public Button StartBoutton, QuitBoutton;
    

    void Start()
    {
        StartBoutton.GetComponent<Button>().onClick.AddListener(Play); //AddListener permet de donner l'info qu'il faut que le boutton s'active si on clique dessus
        QuitBoutton.GetComponent<Button>().onClick.AddListener(ExitGame);
    }


    void Play()
    {
        SceneManager.LoadScene(3);
    }

    void ExitGame()
    {
        Debug.Log("Jeu arrêté");
        Application.Quit();
    }

}
