using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BigSpider : S_Enemy
{
    public GameObject objectToThrow;

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
        
        if (base.canAttack)
        {
            base.canAttack = false;
            GameObject projectile = Instantiate(objectToThrow, transform.position, transform.rotation);

            Rigidbody projectileRB = projectile.GetComponent<Rigidbody>();

            projectileRB.AddForce(transform.right * 10, ForceMode.Impulse);

            Invoke(nameof(ResetAttack), .2f);
        }
    }
}
