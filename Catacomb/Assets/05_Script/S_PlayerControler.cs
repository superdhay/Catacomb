using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerControler : MonoBehaviour
{

    private CharacterController PlayerCTRL;
    private Animator animationCTRL;

    public float PlayerSpeed, JumpSpeed;
    private float AxisH, AxisV, DeplacementY; 
    private float Gravity = 9.8f;

    private Vector3 Deplacement;

    private bool isOnGround, isRunning;
    private bool Flag_Climb;


    void Start()
    {
        PlayerCTRL = GetComponent<CharacterController>();
        animationCTRL = GetComponent<Animator>();
        Flag_Climb = false;

    }

    void Update()
    {
        AxisH = Input.GetAxis("Horizontal");
        AxisV = Input.GetAxis("Vertical");
        animationCTRL.SetFloat("AxisH", AxisH);
        animationCTRL.SetFloat("AxisV", AxisV);

        animationCTRL.SetBool("isOnGround", isOnGround);
        animationCTRL.SetBool("isClimbing", GameManager.isClimbing);
        animationCTRL.SetBool("isRunning", isRunning);


        isOnGround = PlayerCTRL.isGrounded;




        if (Input.GetAxis("Jump") >= 0.1f)
        {
            animationCTRL.SetTrigger("Jump");
            DeplacementY = JumpSpeed;
        }

        //Action pour Déplacer le personnage sur l'axe X
        Deplacement = new Vector3(AxisH, 0, 0);
        Deplacement = this.transform.TransformDirection(Deplacement);
        Deplacement = Deplacement * PlayerSpeed;


        //Setup pour faire sauter le personnage
        DeplacementY = DeplacementY - Gravity * Time.deltaTime;
        if (DeplacementY <= -1.0f) DeplacementY = -1.0f;
        Physics.SyncTransforms();
        Deplacement.y = DeplacementY;


        if (GameManager.isClimbing == true)
        {

            if (Input.GetAxis("Fire1") >= 0.9f)
            {
                Flag_Climb = !Flag_Climb;
                animationCTRL.SetTrigger("Climb");
            }

            if (Flag_Climb == true)
            {
                Gravity = 0f;
                //animationCTRL.applyRootMotion = false;

                Deplacement = new Vector3(0, AxisV, 0);
                Deplacement = transform.TransformDirection(Deplacement); //Calcul le Deplacement relatif au personnage et non pas au world
                Deplacement = Deplacement * PlayerSpeed;
            }
            else
            {
                Gravity = 9.8f;
                animationCTRL.applyRootMotion = true;
            }

        }


        PlayerCTRL.Move(Deplacement * Time.deltaTime); //Fait bouger le personnage selon les parametres de transform setup au dessus
    }
}
