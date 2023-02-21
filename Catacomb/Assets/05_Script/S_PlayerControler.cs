using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerControler : MonoBehaviour
{

    private CharacterController PlayerCTRL;
    private Animator AnimationCTRL;

    public float PlayerSpeed, JumpSpeed;
    private float AxisH, AxisV, DeplacementY; 
    public float Gravity;

    private Vector3 Deplacement;

    private bool isOnGround, isRunning;
    private bool Flag_Climb;


    void Start()
    {
        PlayerCTRL = GetComponent<CharacterController>();
        AnimationCTRL = GetComponent<Animator>();
        Flag_Climb = false;

    }

    void Update()
    {
        AxisH = Input.GetAxis("Horizontal");
        AxisV = Input.GetAxis("Vertical");
        AnimationCTRL.SetFloat("AxisH", AxisH);
        AnimationCTRL.SetFloat("AxisV", AxisV);

        AnimationCTRL.SetBool("isOnGround", isOnGround);
        AnimationCTRL.SetBool("isClimbing", GameManager.isClimbing);
        AnimationCTRL.SetBool("isRunning", isRunning);


        isOnGround = PlayerCTRL.isGrounded;



        if (Input.GetAxis("Fire1") >= 0.9f)
        {
            Flag_Climb = !Flag_Climb;
            AnimationCTRL.SetTrigger("Climb");
        }


        if (Input.GetAxis("Jump") >= 0.1f) DeplacementY = JumpSpeed;

        //Action pour Déplacer le personnage sur l'axe X
        Deplacement = new Vector3(AxisH, 0, 0);
        Deplacement = this.transform.TransformDirection(Deplacement);
        Deplacement = Deplacement * PlayerSpeed;


        //Setup pour faire sauter le personnage
        DeplacementY = DeplacementY - Gravity * Time.deltaTime;
        if (DeplacementY <= -1.0f) DeplacementY = -1.0f;
        Physics.SyncTransforms();
        Deplacement.y = DeplacementY;


        if (Flag_Climb == true)
        {
            GameManager.isClimbing = true;
            Gravity = 0;
            AnimationCTRL.applyRootMotion = false;

            Deplacement = new Vector3(0, AxisV, 0);
            Deplacement = transform.TransformDirection(Deplacement); //Calcul le Deplacement relatif au personnage et non pas au world
            Deplacement = Deplacement * PlayerSpeed;
 
        }
        else
        {
            GameManager.isClimbing = false;
            Gravity = 9.8f;
            AnimationCTRL.applyRootMotion = true;
        }


        PlayerCTRL.Move(Deplacement * Time.deltaTime); //Fait bouger le personnage selon les parametres de transform setup au dessus
    }
}
