using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ExtraLife : MonoBehaviour
{
    GameObject LBoy;
    public AudioClip SOund;
    public GameObject FX;

    void Start()
    {
        LBoy = GameObject.FindGameObjectWithTag("Player");

        if (GameManager.Flag_ExtraLife) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {
            GameManager.Flag_ExtraLife = true;
            GameManager.PV = 4;
            gameObject.GetComponent<AudioSource>().PlayOneShot(SOund);
            Instantiate(FX, transform.position, Quaternion.Euler(0, 0, 0));
            Destroy(gameObject,0.5f);
        }

    }

}
