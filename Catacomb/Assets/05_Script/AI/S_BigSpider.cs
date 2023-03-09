using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BigSpider : S_Enemy
{
    public GameObject objectToThrow;
    
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
        
        if (base.canAttack)
        {
            //Play Anim
            base.animator.SetBool("IsAttacking", true);

            base.canAttack = false;
            GameObject projectile = Instantiate(objectToThrow, transform.position, transform.rotation);
            projectile.SetActive(true);

            Rigidbody projectileRB = projectile.GetComponent<Rigidbody>();

            projectileRB.AddForce(transform.forward * 10, ForceMode.Impulse);
            Destroy(projectile, 4f);

            Invoke(nameof(ResetAttack), 1f);
            
        }
    }
    
}
