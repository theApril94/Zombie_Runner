using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target; //Transform dlatego, ¿e szukamy gdzie nasz obiekt znajduje siê w œwiecie
    [SerializeField] float chaseRange = 5f; //jak daleko od rpzeciwnika mo¿e przebywaæ player by nie zostaæ zauwa¿onym
    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity; //jak daleko jest przeciwnik od playera

    bool isProvoked = false;

    EnemyHealth health;

    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health  = GetComponent<EnemyHealth>();
    }

   
    void Update()
    {
        if(health.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }
        distanceToTarget = Vector3.Distance(target.position, transform.position); 
        if(isProvoked)
        {
            EngageTarget();
        }
        else if(distanceToTarget <= chaseRange)
        {
            isProvoked = true;

            navMeshAgent.SetDestination(target.position); //ustaw pozycjê navmeshagent w pozycji gdzie znajduje siê cel/ gracz
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();

        if(distanceToTarget >= navMeshAgent.stoppingDistance) 
        {
            ChaseTarget();
        }

        if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
        
        
    }

   

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized; //normilized bo zwraca magnitude
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);

        void OnDrawGizmosSelected()
        {
            //rysuje zasiêg widocznoœci przez przeciwnika
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, chaseRange);
        }

    }

}
