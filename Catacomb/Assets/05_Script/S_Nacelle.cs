using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Nacelle : MonoBehaviour
{
    public int SceneID;
    public float Timer;

    public GameObject Transition;
    GameObject Player;

    private void Awake()
    {
        gameObject.GetComponent<Animator>().enabled = false;
        Timer = 6f;

        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && GameManager.Flag_Cranck == true && GameManager.Flag_Use)
        {
            Timer = 0;
        }

    }

    private void Update()
    {
        Timer = Timer + Time.deltaTime;

        if (Timer >= 0 && Timer <= 4)
        {
            Player.GetComponent<CharacterController>().enabled = false;
            Player.GetComponent<Animator>().enabled = false;
            Transition.SetActive(true);
            gameObject.GetComponent<Animator>().enabled = false;
        }
        if (Timer >= 3.9 && Timer <= 4)
        {
            Player.GetComponent<CharacterController>().enabled = true;
            Player.GetComponent<Animator>().enabled = true;
        }

        if (Timer >= 4 && Timer <= 5)
        {
            Timer = 6;
            Transition.SetActive(false);
            SceneManager.LoadScene(SceneID);
        }
    }
}
