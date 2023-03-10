using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class S_PlayerControler : MonoBehaviour
{

    PlayerInput playerInputs;
    CharacterController characterCTRL;
    Animator animationCTRL;
    GameObject cam;
    GameObject Shiny_Light;
    GameObject resume;
    public GameObject Prefab_Attack;
    GameObject ValeurOrbes;
    public GameObject Spawner;
    public GameObject Magic;
    public GameObject Magic2;

    public GameObject CamRight, CamLeft;


    // Variables pour les mouvements: déplacements, physique et sauts
    Vector2 currentMovementInput;
    Vector3 currentMovement;
    Vector3 currentRunningMovement;

    float rotationFactorPerFrame = 30.0f;
    public float gravity;
    public float maxJumpHeight = 2.4f;
    public float maxJumpTime = 0.7f;
    float initialJumpVelocity;
    public float PlayerSpeed, RunSpeed;
    float StaminaDuration = 5;

    float AxisH, AxisV;
    float timerLuminosity, Cooldown;

    //Flag
    bool isJumpPressed = false;
    bool isMoving, isRunning, isJumping, isInteracting, isAttacking, isAddLuminosity, isResuming;
    bool isOnGround, Climb_Flag, Flag_Luminosity;
    public bool isRight;

    public bool Flag_Item_Key, Flag_Item_Cranck;


    public void Awake()
    {
        playerInputs = new PlayerInput();
        characterCTRL = GetComponent<CharacterController>();
        animationCTRL = GetComponent<Animator>();
        cam = GameObject.Find("Main Camera");
        Shiny_Light = GameObject.Find("ShinyLight");
        Spawner = GameObject.Find("SpawnProjo");
        resume = GameObject.Find("Resume");

        //CamLeft = GameObject.Find("MainCameraLeft");
        //CamRight = GameObject.Find("MainCameraRight");

        ValeurOrbes = GameObject.Find("QuantitéOrbes");
        ValeurOrbes.GetComponent<Text>().text = GameManager.Orbes.ToString();

        timerLuminosity = 6;
        Cooldown = 0;

        Flag_Item_Key = GameManager.Flag_Key;
        Flag_Item_Cranck = GameManager.Flag_Cranck;

        //Setup entre l'input et son action
        playerInputs.L_Boy.Move.started += onMouvementInput;
        playerInputs.L_Boy.Move.performed += onMouvementInput;
        playerInputs.L_Boy.Move.canceled += onMouvementInput;

        playerInputs.L_Boy.Run.started += onRun;
        playerInputs.L_Boy.Run.canceled += onRun;

        playerInputs.L_Boy.Jump.started += onJump;
        playerInputs.L_Boy.Jump.canceled += onJump;

        playerInputs.L_Boy.Interact.started += onInteract;
        playerInputs.L_Boy.Interact.canceled += onInteract;

        playerInputs.L_Boy.Attack.started += onAttack;
        playerInputs.L_Boy.Attack.canceled += onAttack;

        playerInputs.L_Boy.Luminosity.started += onLuminosity;
        playerInputs.L_Boy.Luminosity.canceled += onLuminosity;



        setupJumpVariable();
    }

    private void Start()
    {
        if (transform.rotation.y == 0)
        {
            isRight = true;
            CamRight.SetActive(true);
            CamLeft.SetActive(false);
        }
        else
        {
            isRight = false;
            CamRight.SetActive(false);
            CamLeft.SetActive(true);
        }
    }


    void handleRotation()
    {

        Vector3 positionToLookAt;

        positionToLookAt.x = currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentMovement.z;

        Quaternion currentRotation = transform.rotation;

        if (isMoving)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }
        

    }



    void setupJumpVariable()
    {

        float timeToApex = maxJumpTime / 2;
        gravity = (-1 * maxJumpHeight) / Mathf.Pow(timeToApex, 1);
        initialJumpVelocity = (1 * maxJumpHeight) / timeToApex;

    }

    void Jump()
    {

        if (!isJumping && isOnGround && isJumpPressed)
        {
            isJumping = true;
            animationCTRL.SetBool("isJumping", true);
            //Physics.SyncTransforms();
            currentMovement.y = initialJumpVelocity;
            currentRunningMovement.y = initialJumpVelocity;
        }
        else if (!isJumpPressed && isJumping && isOnGround)
        {
            isJumping = false;
        }


    }




    void Interact()
    {

        if (isInteracting == true)
        {
            Debug.Log("L.Boy is interacting with something!");

            GameManager.Flag_Statue_On = true;
            GameManager.Flag_Bougeoir_On = true;

            GameManager.Flag_Use = true;
            GameManager.Flag_Dig = true;

            Climb_Flag = true;

        }
        else
        {
            GameManager.Flag_Statue_On = false;
            GameManager.Flag_Bougeoir_On = false;

            GameManager.Flag_Use = false;
            GameManager.Flag_Dig = false;

            Climb_Flag = false;
        }

        if (GameManager.isClimbing && Climb_Flag)
        {

            animationCTRL.SetBool("isClimbing", true);
            animationCTRL.SetFloat("AxisV", AxisV);

            currentMovement.y = currentMovementInput.y * 2;
            currentMovement.z = 0;
            currentMovement.x = 0;
            currentMovementInput.x = 0;
            //transform.rotation = Quaternion.Euler(0, -180, 0);

            gravity = 0f;

            animationCTRL.applyRootMotion = false;
            isMoving = false;
            isRunning = false;


        }
        else
        {
            
            animationCTRL.applyRootMotion = true;
            animationCTRL.SetBool("isClimbing", false);
            animationCTRL.SetFloat("AxisV", 0);

        }



    }


    void Luminosity()
    {

        if (isAddLuminosity && GameManager.Orbes >= 2 && Cooldown >= 1)
        {

            Cooldown = 0;
            timerLuminosity = 0;

            GameManager.Orbes = GameManager.Orbes - 2;
            ValeurOrbes.GetComponent<Text>().text = GameManager.Orbes.ToString();

        }

        if (timerLuminosity <= 5) Shiny_Light.GetComponent<Light>().range = 5;
        else Shiny_Light.GetComponent<Light>().range = 2;

    }


    void Gravity()
    {
        float groundedGravity = 0.05f;
        //float fallMultiplier = 5.0f;
        isOnGround = characterCTRL.isGrounded;
        bool isFalling = currentMovement.y <= 0.0f;

        if (isOnGround)
        {
            animationCTRL.SetBool("isJumping", false);
            currentMovement.y += groundedGravity;
            currentRunningMovement.y += groundedGravity;
        }
        else if (isFalling)
        {
            currentMovement.y += gravity /* * fallMultiplier*/ * Time.deltaTime;
            currentRunningMovement.y += gravity /* * fallMultiplier*/ * Time.deltaTime;
        }
        else
        {
            currentMovement.y += gravity * Time.deltaTime;
            currentRunningMovement.y += gravity * Time.deltaTime;
        }

        animationCTRL.SetBool("isOnGround", isOnGround);
    }


    void animationManager()
    {

        AxisH = currentMovement.z;
        AxisV = currentMovement.y;


        if (isMoving) animationCTRL.SetFloat("AxisH", AxisH);
        else if (!isMoving) animationCTRL.SetFloat("AxisH", 0);

        if (isRunning && AxisH != 0) animationCTRL.SetBool("isRunning", true);
        else animationCTRL.SetBool("isRunning", false);

    }

    public void Fire()
    {
        //GameObject Projectile = Instantiate(Prefab_Attack, Spawner.transform.position, Spawner.transform.localRotation);
        GameObject Projectile = Instantiate(Prefab_Attack, Spawner.transform.position, Quaternion.Euler(-90,0,0) );
        Projectile.GetComponent<Rigidbody>().AddForce(Spawner.transform.forward * 1000);
        
        if (isRight) Projectile.transform.rotation = Quaternion.Euler(0, 90, 0);
        if (!isRight) Projectile.transform.rotation = Quaternion.Euler(0, -90, 0);
    }



    void Update()
    {

        Time.timeScale = 1;
        Cooldown = Cooldown + Time.deltaTime;
        timerLuminosity = timerLuminosity + Time.deltaTime;

        if (transform.rotation.y == 0)
        {
            isRight = true;
            CamRight.SetActive(true);
            CamLeft.SetActive(false);
        }
        else
        {
            isRight = false;
            CamRight.SetActive(false);
            CamLeft.SetActive(true);
        }

        setupJumpVariable();

        handleRotation();
        animationManager();
        Luminosity();
        Resume();

        if (isAttacking && GameManager.Orbes >= 1 && Cooldown >= 1)
        {
            
            Cooldown = 0;
            GameManager.Orbes = GameManager.Orbes - 1;
            ValeurOrbes.GetComponent<Text>().text = GameManager.Orbes.ToString();

            Magic.GetComponent<Animator>().SetTrigger("Fire");
            Magic2.GetComponent<Animator>().SetTrigger("Fire");
            animationCTRL.SetTrigger("Fire");

        }




        if (isRunning) characterCTRL.Move(currentRunningMovement * Time.deltaTime);
        else characterCTRL.Move(currentMovement * Time.deltaTime);

        Gravity();

        Interact();

        //cam.transform.position = new Vector3(1f, (transform.position.y + 1f), transform.position.z);
        
        
        //cam.transform.LookAt(transform.position);

        Jump();

        if (GameManager.PV <= 0) animationCTRL.SetBool("isDying", true);

        Climb_Flag = GameManager.isClimbing;
    }


    void Resume()
    {
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


    void onJump(InputAction.CallbackContext context)
    {
        isJumpPressed = context.ReadValueAsButton();

    }

    void onRun(InputAction.CallbackContext context)
    {
        isRunning = context.ReadValueAsButton();
    }

    void onMouvementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.z = currentMovementInput.x * PlayerSpeed;
        //currentMovement.z = currentMovementInput.y;
        currentRunningMovement.z = currentMovementInput.x * RunSpeed;

        isMoving = currentMovementInput.x != 0;
    }

    void onInteract(InputAction.CallbackContext context)
    {
        isInteracting = context.ReadValueAsButton();
    }

    void onAttack(InputAction.CallbackContext context)
    {
        isAttacking = context.ReadValueAsButton();
    }

    void onLuminosity(InputAction.CallbackContext context)
    {
        isAddLuminosity = context.ReadValueAsButton();
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
