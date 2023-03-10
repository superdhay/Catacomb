using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DamageElement : MonoBehaviour
{
    float TimerDamage;

    void Start()
    {
        TimerDamage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TimerDamage = TimerDamage + Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && TimerDamage >= 1) 
        {
            GameManager.PV = GameManager.PV - 1;
            TimerDamage = 0;
        }
    }
}
