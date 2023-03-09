using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Projectile : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        gameObject.SetActive(true);
    }


    //Function that manage the collision of the projectile.
    private void OnTriggerEnter(Collider collision)
    {

        //Verify if it is the player that is hit.
        if (collision.tag ==Player.tag)
        {
            Debug.Log("hit");
            GameManager.PV--;
            gameObject.SetActive(false);
            Destroy(this, .1f);
        }
        gameObject.SetActive(false);
        Destroy(this, .1f);
    }
}
