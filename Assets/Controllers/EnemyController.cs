using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* Controls the Enemy AI */

public class EnemyController : MonoBehaviour
{


    public float lookRadius = 10f;  // Detection range for player

    Transform target;   // Reference to the player
    NavMeshAgent agent; // Reference to the NavMeshAgent
    private Vector3 spawnPos;
    private float waitTime;
    private float StartWaitTime=5;
    private Animator mAnimator;
    private Vector3 destination;



    // Use this for initialization
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        spawnPos = transform.position;
        waitTime = StartWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Distance to the target
        float distance = Vector3.Distance(target.position, transform.position);

        // If inside the lookRadius
        if (distance <= lookRadius)
        {
            // Move towards the target
            destination = target.position;
            agent.SetDestination(destination);
            bool walking = true;
            mAnimator.SetBool("walking", walking);

        }
        if (Vector3.Distance(transform.position, spawnPos) > 0.2f)
        {
            if (waitTime <= 0)
            {
                destination = spawnPos;
                agent.SetDestination(destination);
                waitTime = StartWaitTime;
                bool walking = true;
                mAnimator.SetBool("walking", walking);
            }
        }
        waitTime -= Time.deltaTime;
        if (Vector3.Distance(transform.position, destination) < 1f)
        {
            bool walking = false;
            mAnimator.SetBool("walking", walking);
        }
       // if(Vector3.Distance(transform.position, target.position) < 0.2f){
       //     mAnimator.SetTrigger("attack");
       // }

    }

    // Rotate to face the target
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }



    // Show the lookRadius in editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
