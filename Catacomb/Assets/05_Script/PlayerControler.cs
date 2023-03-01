using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    public bool Climb_Flag;

    PlayerInput playerInputs;
    CharacterController characterCTRL;
    Animator animationCTRL;


 // Variables pour les mouvements: déplacements, physique et sauts
    Vector2 currentMovementInput;
    Vector3 currentMovement;
    Vector3 currentRunningMovement;

    float AxisH;

    bool isJumpPressed = false;
    bool isMoving, isRunning, isJumping, isInteracting;
    public bool isOnGround;

    float rotationFactorPerFrame = 30.0f;
    public float gravity;
    public float maxJumpHeight = 2.0f;
    public float maxJumpTime = 0.5f;
    float initialJumpVelocity;
    public float PlayerSpeed, RunSpeed;



    public void Awake()
    {
        playerInputs = new PlayerInput();
        characterCTRL = GetComponent<CharacterController>();
        animationCTRL = GetComponent<Animator>();

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

        setupJumpVariable();
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
            Physics.SyncTransforms();
            currentMovement.y = initialJumpVelocity;
            currentRunningMovement.y = initialJumpVelocity;
        }
        else if (!isJumpPressed && isJumping && isOnGround)
        {
            isJumping = false;
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

    void onMouvementInput (InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x * PlayerSpeed;
        //currentMovement.z = currentMovementInput.y;

        currentRunningMovement.x = currentMovementInput.x * RunSpeed;

        isMoving = currentMovementInput.x != 0;//|| currentMovementInput.y != 0;
    }

    void onInteract(InputAction.CallbackContext context)
    {
        isInteracting = context.ReadValueAsButton();
        Debug.Log(isInteracting);
    }



    void interact()
    {

        if (isInteracting == true)
        {

            GameManager.Flag_Statue_On = true;
            GameManager.Flag_Bougeoir_On = true;

            Climb();

        }

    }



    void Climb()
    {

        if (GameManager.isClimbing)
        {

            animationCTRL.SetBool("isClimbing", true);

            currentMovement.y = currentMovementInput.y * 2;
            currentMovement.x = 0;

            gravity = 2f;
            //animationCTRL.applyRootMotion = false;


        }
        else
        {
            //float timeToApex = maxJumpTime / 2;
            gravity = -8;//(-1f * maxJumpHeight) / Mathf.Pow(timeToApex, 1);
            //animationCTRL.applyRootMotion = true;
            animationCTRL.SetBool("isClimbing", false);

        }

    }


    void Gravity()
    {
        float groundedGravity = 0.05f;
        float fallMultiplier = 2.0f;
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
            currentMovement.y += gravity * fallMultiplier * Time.deltaTime;
            currentRunningMovement.y += gravity * fallMultiplier * Time.deltaTime;
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

        AxisH = currentMovement.x;


        if (isMoving) animationCTRL.SetFloat("AxisH", AxisH);
        else if (!isMoving) animationCTRL.SetFloat("AxisH", 0);

        if (isRunning && AxisH !=0) animationCTRL.SetBool("isRunning", true);
        else animationCTRL.SetBool("isRunning", false);

    }


    void Update()
    {
        handleRotation();
        animationManager();
        interact();

        if (isRunning) characterCTRL.Move(currentRunningMovement * Time.deltaTime);
        else characterCTRL.Move(currentMovement * Time.deltaTime);

        Gravity();
        Jump();

        Climb_Flag = GameManager.isClimbing;
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
