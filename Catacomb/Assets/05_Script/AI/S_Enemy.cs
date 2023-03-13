using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class S_Enemy : MonoBehaviour
{

    //Enemy stats.
    [SerializeField]
    private int LifePoint = 2;

    //Walk speed that can be set in Inpsector.
    [SerializeField]
    private float MoveSpeed = 2f;

    //Seconds interval between which the Enemy will attack.
    [SerializeField]
    private float AttackDelay = 1.5f;

    //Variable to verify if the enemy is dead.
    private bool IsDead = false;


    //Array of waypoints to walk from one to the next.
    [SerializeField]
    private Transform[] Waypoints;

    // Index of current waypoints from which  Enemy walks to the next one.
    private int WaypointIndex = 0;
    private bool isEndPatrol = false;

    private bool PlayerDetected = false;
    private bool CanAttack = true;

    public Animator Animator;


//////////////////////////////////////////////////////////////////////////////////


    // Start is called before the first frame update
    public void Start()
    {
        //Set the position of enemy as position to the first waypoint.
        transform.position = Waypoints[0].transform.position;
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (!IsDead)
        {
            //Move Enemy.
            if (!PlayerDetected && !IsDead)
            {
                Move();
                Animator.SetBool("IsAttacking", false);
            }

            //Cast a ray for player detection.
            EnemyVision();
        }
        
    }


    //Method that actually make enemy walks.
    public void Move()
    {

        //If Enemy didn't reach last waypoint it can move.
        //If Enemy reached the last waypoint then it comes back.
        if (WaypointIndex <= Waypoints.Length - 1)
        {
            //Move Enemy from current waypoint to the next one using MoveTowards method.
            transform.position = Vector3.MoveTowards(
                transform.position,
                Waypoints[WaypointIndex].transform.position,
                MoveSpeed * Time.deltaTime
            );

            //Set moving to true.
            Animator.SetBool("IsMoving", true);

            //Make enemy rotate when it arrives at each ends
            if (transform.position.z == Waypoints[Waypoints.Length - 1].transform.position.z)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
            }
            if (transform.position.z == Waypoints[0].transform.position.z)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            }

            //If Enemy reaches position of waypoint he walked towards
            //Then waypointIndex is increased by 1
            //And Enemy starts to walk to the next waypoint.
            if (transform.position.z == Waypoints[WaypointIndex].transform.position.z)
            {
                if (isEndPatrol == true)
                {
                    WaypointIndex--;
                    if (WaypointIndex == 0)
                    {
                        isEndPatrol = false;
                    }
                }
                else if (isEndPatrol == false)
                {
                    WaypointIndex++;
                    if (WaypointIndex == Waypoints.Length-1)
                    {
                        isEndPatrol = true;
                    } 
                }
            }
        }
    }

    //Function that cast a ray to detect the player.
    public void EnemyVision()
    {
        Vector3 rayStartPosition = new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z+.5f);
        //Debug cast.
        Debug.DrawRay(rayStartPosition, transform.forward * 10);

        //Cast ray
        RaycastHit hit;
        if (Physics.Raycast(new Ray(rayStartPosition, transform.forward * 10), out hit, 10))
        {
            //Verify if the player is touch.
            if (hit.collider.tag == "Player")
            {
                //Set player detected.
                PlayerDetected = true;

                //Stop enemy moves.
                Animator.SetBool("IsMoving", false);

                //Enemy attacks.
                AttackPlayer(hit.transform.position);
            }
        }
        
    }

    /*
     * Function that will manage enemy attack.
     * 
     * @param playerPosition (Vector3) : the position of the player when he was hit by the detection ray.
     */
    public abstract void AttackPlayer(Vector3 playerPosition);


    //Function that reset the posibility of the enemy to attack.
    public void ResetAttack()
    {
        CanAttack = true;
    }


    /*
     * Function that manage the enemy
     * 
     * @param damage (int) : the amount of damage the enemy will receive.
     */
    public void ReceiveDamage(int damage)
    {
        SetLifePoint(GetLifePoint() - damage);
        if(GetLifePoint() <= 0)
        {
            SetIsDead(false);
            Animator.SetBool("IsDead", true);
            SetCanAttack(false);
            Destroy(gameObject, 1.5f);
        }
    }


////////////////////////////////////////////////////////////////////////////////////////////
//Getter - Setter 

    //Life points
    public int GetLifePoint()
    {
        return LifePoint;
    }

    public void SetLifePoint(int lifePoint)
    {
        LifePoint = lifePoint;
    }

    //Move speed
    public float GetMoveSpeed()
    {
        return MoveSpeed;
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        MoveSpeed = moveSpeed;
    }

    //Attack delay
    public float GetAttackDelay()
    {
        return AttackDelay;
    }

    public void SetAttackDelay(float attackDelay)
    {
        AttackDelay = attackDelay;
    }

    //Is dead
    public bool GetIsDead()
    {
        return IsDead;
    }

    public void SetIsDead(bool isDead)
    {
        IsDead = isDead;
    }

    //Can Attack
    public bool GetCanAttack()
    {
        return CanAttack;
    }

    public void SetCanAttack(bool canAttack)
    {
        CanAttack = canAttack;
    }
}
