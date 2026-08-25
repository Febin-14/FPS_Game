 using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.Animations;
using UnityEngine.Rendering;
using UnityEngine.Video;

public abstract class EnemySystem : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] protected float health = 100f;
    [SerializeField] protected float patrolSpeed = 1f;
    [SerializeField] protected float chaseSpeed = 6f;
    [SerializeField] protected int damageAmt = 25;
    [SerializeField] protected float attackRange = 10f;
    [SerializeField] protected float detectRange = 50f;
    [SerializeField] protected Transform patrolStart;
    [SerializeField] protected Transform patrolEnd;
    
    [Header("Debug")]
    [SerializeField] private bool debugIsStopped;
    [SerializeField] private float debugVelocity;
    [SerializeField] private bool debugHasPath;


    protected Transform player;
    protected float currentHealth;
    protected bool isDead = false;
    protected NavMeshAgent agent;
    protected Animator animator;
    protected EnemyState currentState;
    protected float distanceToPlayer;
    protected Transform currentPatrolTarget;
    private float nextPathUpdate;
    [SerializeField] private float pathUpdateInterval = 0.2f;
    protected virtual void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponentInChildren<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        currentHealth = health;
    


    }
    protected virtual void Start()
    {
        currentState = EnemyState.Patrol;
        currentPatrolTarget = patrolStart;
    }
    protected virtual void Update()
    { 
        debugIsStopped = agent.isStopped;
        debugVelocity = agent.velocity.magnitude;
        debugHasPath = agent.hasPath;


        distanceToPlayer = FindDistance();
        if (isDead && currentState != EnemyState.Dead)
        return;
        switch(currentState)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Patrol:
                Patrol();
                break;
            case EnemyState.Chase:
                agent.speed = chaseSpeed;
                Chase();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Dead:
                Die();
                break;
        }

    }
    public virtual void TakeDamage(float amount)
    {
        if(isDead)
        {
            return;
        }
        currentHealth -= amount;
        Debug.Log($"Enemy took {amount} damage. Current health: {currentHealth}");
        if (currentHealth <= 0)
        {
            Debug.Log("Enemy has died.");
            ChangeState(EnemyState.Dead);
        }
    }
    protected virtual void Die()
    {
        if(isDead)
        {
            isDead = true;
        } 

        agent.isStopped = true;
        Debug.Log("Enemy has died.");
        //animator.CrossFade("Death", 0.05f);

    }
    protected virtual void Attack()
    {
    
 
    }
    protected virtual void Chase()
    {

        agent.SetDestination(player.position);

        animator.SetFloat("speed", agent.velocity.magnitude);

        if (distanceToPlayer <= attackRange)
        {
            ChangeState(EnemyState.Attack);
            return;
        }

        if (distanceToPlayer > detectRange)
        {
            ChangeState(EnemyState.Patrol);
        }
    }
    protected virtual void Patrol()
    {

        agent.SetDestination(currentPatrolTarget.position);

        animator.SetFloat("speed", agent.velocity.magnitude);

        if (!agent.pathPending &&
            agent.remainingDistance <= agent.stoppingDistance)
        {
            currentPatrolTarget =
                currentPatrolTarget == patrolStart
                ? patrolEnd
                : patrolStart;
        }

        if (canSeePlayer())
        {
            ChangeState(EnemyState.Chase);
        }
    }
    protected virtual bool canSeePlayer()
    {
        return distanceToPlayer <= detectRange;
    }
    protected virtual void Idle()
    {
        //Play Idle animation
    }
    public enum EnemyState
    {
        Idle,
        Patrol,
        Chase,
        Attack,
        Dead
    }
    protected float FindDistance()
    {

        return Vector3.Distance(agent.transform.position, player.position);
    }
    protected void ChangeState(EnemyState newstate)
    {
        if(currentState == newstate)
        {
            return;
        }
        currentState = newstate;
        switch (newstate)
        {
            case EnemyState.Idle:
                agent.isStopped = true;
                break;
            case EnemyState.Patrol:
                agent.isStopped = false;
                agent.speed = patrolSpeed;
                break;

            case EnemyState.Chase:
                agent.isStopped = false;
                agent.speed = chaseSpeed;
                break;

            case EnemyState.Attack:
                agent.isStopped = true;
                agent.ResetPath();
                break;
            case EnemyState.Dead:
                agent.isStopped = true;
                break;
        }
    }
    protected virtual void FacePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    private void OnDrawGizmosSelected()
    {
        Transform origin = transform.childCount > 0 ? transform.GetChild(0) : transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(origin.position, detectRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(origin.position, attackRange);
    }

}
