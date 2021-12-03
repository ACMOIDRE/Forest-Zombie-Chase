using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 4f;
    bool isProvoked = false;

    EnemyHealth health;
    Transform target;

    // navagent 

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        target =  FindObjectOfType<PlayerHealth>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (health.IsDead()){
            navMeshAgent.enabled = false;
            enabled = false;
        }
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;

        }

    }

    private void EngageTarget()
    {
        FaceTarget();

        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }

    }
    private void ChaseTarget()
    {

        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);

        
    }
    private void AttackTarget()
    {

        GetComponent<Animator>().SetBool("attack", true);
        
        
    }

    private void FaceTarget()
    {
        //find normalized direction b/w target(player)-transform.postion(gameobj enemy)
        Vector3 direction = (target.position - transform.position).normalized;
        // lookrotation forward vector Gameobj(enemy)
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        // slerp current.transform.rotation, lookrotation , time 
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}
