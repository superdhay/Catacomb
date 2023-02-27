using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BigSpider : S_Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public override void AttackPlayer(Vector3 playerPosition)
    {
        Debug.Log("Toucher");
    }
}
