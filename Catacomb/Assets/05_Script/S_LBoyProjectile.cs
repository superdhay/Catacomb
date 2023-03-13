using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_LBoyProjectile : MonoBehaviour
{
    float LifeTime;
    
    void Start()
    {
        LifeTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        LifeTime = LifeTime + Time.deltaTime;

        if (LifeTime > 2) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<S_Enemy>().ReceiveDamage(1);
            Destroy(gameObject);
        }
    }
}
