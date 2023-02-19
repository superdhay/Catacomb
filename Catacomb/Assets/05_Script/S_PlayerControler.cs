using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerControler : MonoBehaviour
{

    private CharacterController PlayerCTRL;

    public float PlayerSpeed, JumpSpeed;
    private float AxisH, DeplacementY; 
    public float Gravity;

    private Vector3 Deplacement;

    private bool isOnGround;


    void Start()
    {
        PlayerCTRL = GetComponent<CharacterController>();

    }

    void Update()
    {
        AxisH = Input.GetAxis("Horizontal");

        isOnGround = PlayerCTRL.isGrounded;

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

        PlayerCTRL.Move(Deplacement * Time.deltaTime);  //Fait bouger le personnage selon les parametres de transform setup au dessus

    }
}
