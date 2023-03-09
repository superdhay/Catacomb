using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_Key : MonoBehaviour
{
    GameObject Icon;

    void Start()
    {
        Icon = GameObject.Find("Key");
        Icon.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Flag_Key = true;
            Icon.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (GameManager.Flag_Key) Destroy(gameObject);
    }
}
