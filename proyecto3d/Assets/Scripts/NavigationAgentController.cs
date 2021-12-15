using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationAgentController : MonoBehaviour
{
    [Header("Path Finding")]
    [SerializeField, Tooltip("Object to chase.")]
    Transform target;

    [SerializeField, Tooltip("Distance to Target to start chasing.")]
    float chaseRange = 5.0F;

    [Tooltip("Navigation Agent.")]
    NavMeshAgent navAgent;

    [Header("Attack")]
    [Space]
    [SerializeField]
    Transform attackPoint;

    [SerializeField]
    float attackRange = 0.5F;

    [SerializeField]
    float damage = 1.0F;

    Animator animator;

    LayerMask whatIsTarget;

    [Tooltip("Flag to indicate when to chase target.")]
    bool chaseTarget;

    [Tooltip("Flag to indicate when character is attacking.")]
    bool isAttacking;

    [Tooltip("Current distance to raget.")]
    float distanceToTarget = Mathf.Infinity;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        //animator = GetComponent<Animator>();
        whatIsTarget = LayerMask.GetMask(LayerMask.LayerToName(target.gameObject.layer));
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget > chaseRange) {
            RaycastHit raycast;
            Physics.Raycast(transform.position, target.position, out raycast);
            if (chaseTarget && raycast.collider && raycast.collider.gameObject != target.gameObject) {
                chaseTarget = false;
                //animator.SetFloat("Speed", 0.0F);
            }
        }
        if (chaseTarget) { EngageTarget(); }
        else if (distanceToTarget <= chaseRange) {
            chaseTarget = true;
            //animator.SetFloat("Speed", 1.0F);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        if (attackPoint)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }

    void EngageTarget()
    {
        if (distanceToTarget >= navAgent.stoppingDistance) { ChaseTarget(); }
        else if (distanceToTarget <= navAgent.stoppingDistance) { AttackTarget(); }
    }
    
    void ChaseTarget() { navAgent.SetDestination(target.position); }
    
    void AttackTarget() { 
        if (animator != null && !isAttacking) { 
            isAttacking = true;
        } 
    }

    public void OnAttack()
    {
        Collider[] colliders = Physics.OverlapSphere(attackPoint.position, attackRange, whatIsTarget);
        if (colliders.Length > 0)
        {
            foreach (Collider collider in colliders)
            {
            }
        }
    }
    
    public void OnAttackEnded() { isAttacking = false; }

}