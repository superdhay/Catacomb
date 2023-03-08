using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SmallSpider : S_Enemy
{
    
    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();
    }

    public override void AttackPlayer(Vector3 playerPosition)
    {
        Debug.Log("Toucher");
    }
    
}
