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

    private void OnTriggerEnter(Collider collision)
    {
       // S_PlayerControler player = collision.gameObject.GetComponent<S_PlayerControler>();

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
