using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class S_Resume : MonoBehaviour
{
    public Button ExitBoutton;
    PlayerInput playerInputs;
    public GameObject resume;
    GameObject LBoy;
    Animator animationCTRL;

    bool isResuming;

    void Start()
    {
        LBoy = GameObject.FindGameObjectWithTag("Player");
        animationCTRL = LBoy.GetComponent<Animator>();
        ExitBoutton.GetComponent<Button>().onClick.AddListener(Exit);
    }

    // Update is called once per frame
    void Update()
    {
        playerInputs = new PlayerInput();

        if (playerInputs.L_Boy.Resume.triggered) isResuming = !isResuming;

        if (isResuming)
        {
            resume.SetActive(true);
            Time.timeScale = 0;
            animationCTRL.enabled = false;
        }
        else
        {
            resume.SetActive(false);
            animationCTRL.enabled = true;
        }
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

    private void OnEnable()
    {
        playerInputs.L_Boy.Enable();
    }

    private void OnDisable()
    {
        playerInputs.L_Boy.Disable();
    }
}
