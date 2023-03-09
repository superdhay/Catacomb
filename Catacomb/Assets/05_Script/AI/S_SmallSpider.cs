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

    /*
     * Function that will manage enemy attack.
     * Override function from S_Enemy.
     * 
     * @param playerPosition (Vector3) : the position of the player when he was hit by the detection ray.
     */
    public override void AttackPlayer(Vector3 playerPosition)
    {
        Debug.Log("Toucher");

        //Move Enemy from current waypoint to the next one using MoveTowards method.
        transform.position = Vector3.MoveTowards(
            transform.position,
            playerPosition,
            (base.GetMoveSpeed() + 1f) * Time.deltaTime
        );
        base.Animator.SetBool("IsMoving", true);

        if (transform.position.z == playerPosition.z)
        {
            base.Animator.SetBool("IsMoving", false);
            base.Animator.SetBool("IsAttacking", true);
        }
    }

    //Function that manage the collision.
    private void OnTriggerEnter(Collider collision)
    {
        //Verify if it is the player that is hit.
        if (collision.tag == "Player")
        {
            Debug.Log("hit");
            GameManager.PV--;
        }
    }
}
