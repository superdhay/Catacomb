using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BigSpider : S_Enemy
{
    [SerializeField]
    private float DestroyDelay = 4f;
    [SerializeField]
    private GameObject ObjectToThrow;


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
        if (base.GetCanAttack())
        {
            //Play Anim
            base.Animator.SetBool("IsAttacking", true);

            base.SetCanAttack(false);

            //Set Spawn position.
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z-.5f);
            GameObject projectile = Instantiate(ObjectToThrow, spawnPosition, transform.rotation);

            //Apply force to throw projectile.
            Rigidbody projectileRB = projectile.GetComponent<Rigidbody>();
            projectileRB.AddForce(transform.forward * 10, ForceMode.Impulse);

            //Destroy projectile after @DestroyDelay seconds.
            Destroy(projectile, DestroyDelay);

            //Reset Attack after @AttackDelay seconds.
            Invoke(nameof(ResetAttack), base.GetAttackDelay());
            
        }
    }
}
