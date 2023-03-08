using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class S_Enemy : MonoBehaviour
{

    //Enemy stats.
    //Walk speed that can be set in Inpsector.
    [SerializeField]
    private float moveSpeed = 2f;


    //Array of waypoints to walk from one to the next.
    [SerializeField]
    private Transform[] waypoints;

    // Index of current waypoints from which  Enemy walks to the next one.
    private int waypointIndex = 0;
    private bool isEndPatrol = false;

    private bool playerDetected = false;
    public bool canAttack = true;

    public Animator animator;


    // Start is called before the first frame update
    public void Start()
    {
        //Set the position of enemy as position to the first waypoint.
        transform.position = waypoints[waypointIndex].transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        //Move Enemy.
        if (!playerDetected)
        {
            Move();
            animator.SetBool("IsAttacking", false);
        }
        

        EnemyVision();
    }






    //Method that actually make enemy walks.
    public void Move()
    {

        //If Enemy didn't reach last waypoint it can move.
        //If Enemy reached the last waypoint then it comes back.
        if (waypointIndex <= waypoints.Length - 1)
        {
            //Move Enemy from current waypoint to the next one using MoveTowards method.
            transform.position = Vector3.MoveTowards(
                transform.position,
                waypoints[waypointIndex].transform.position,
                moveSpeed * Time.deltaTime
            );
            animator.SetBool("IsMoving", true);

            //Make enemy rotate when it arrives at each ends
            if (transform.position.z == waypoints[waypoints.Length - 1].transform.position.z)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
            }
            if (transform.position.z == waypoints[0].transform.position.z)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            }

            //If Enemy reaches position of waypoint he walked towards
            //Then waypointIndex is increased by 1
            //And Enemy starts to walk to the next waypoint.
            if (transform.position.z == waypoints[waypointIndex].transform.position.z)
            {
                if (isEndPatrol == true)
                {
                    waypointIndex--;
                    if (waypointIndex == 0)
                    {
                        isEndPatrol = false;
                    }
                }
                else if (isEndPatrol == false)
                {
                    waypointIndex++;
                    if (waypointIndex == waypoints.Length-1)
                    {
                        isEndPatrol = true;
                    } 
                }
            }
        }
    }


    public void EnemyVision()
    {
        Debug.DrawRay(transform.position, transform.forward * 10);

        RaycastHit hit;
        if (Physics.Raycast(new Ray(transform.position, transform.forward * 10), out hit, 10))
        {
            if (hit.collider.tag == "Player")
            {
                playerDetected = true;
                animator.SetBool("IsMoving", false);
                AttackPlayer(hit.point);
            }
        }
        
    }

    public abstract void AttackPlayer(Vector3 playerPosition);

    public void ResetAttack()
    {
        canAttack = true;
    }
}
