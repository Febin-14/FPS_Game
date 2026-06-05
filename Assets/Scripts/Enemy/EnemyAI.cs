
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent; // Reference to the NavMeshAgent component
    [SerializeField] private Transform SpawnPoint; // The SpawnPoint of Enemy
    public float attackCoolDown = 1.5f;// Cooldown time between attacks
    [SerializeField] private float lastAttackTime = 0f; // Time of the last attack

    private  Transform player; // Reference to the player's transform
    public float AttackRange = 2; // Range within which the enemy will attack the player
    public Transform[] patrolPoints;

    public EnemyState currentState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = EnemyState.Idle; // Set initial state to Idle
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player object by tag and get its transform   
        agent = GetComponent<NavMeshAgent>(); // Get the NavMeshAgent component attached to the enemy game object
    }

    // Update is called once per frame
    void Update()
    {
        StateExecuter(currentState); // Call the state changer to execute behavior based on the current state
        
         // Call the player detection method to check for player presence and update state accordingly

    }
    public enum EnemyState
    {
        Idle,
        Patrol,
        Chase,
        Attack,
        BackToPost,
        Dead
    }
    
    #region Trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentState = EnemyState.Chase; // Change state to Chase when the player enters the trigger
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentState = EnemyState.BackToPost; // Change state to BackToPost when the player exits the trigger
        }
    }
    #endregion


    void StateExecuter(EnemyState state)
    {
        // Implement state change logic here
        //switch for switching between states
        switch(state)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Patrol:
                Patrol();
                break;
            case EnemyState.Chase:
                Chase();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.BackToPost:
                BackToPost();
                break;
            case EnemyState.Dead:
                Dead();
                break;

        }

    }
    void Idle()
    {
        // Implement idle behavior here
    }
    void Patrol()
    {
        // Implement patrol behavior here
    }
    void Chase()
    {
            agent.isStopped = false; // Ensure the NavMeshAgent is not stopped
            // Implement chase behavior here
            agent.SetDestination(player.position); // Set the destination of the NavMeshAgent to the player's position
            float distanceToPlayer = Vector3.Distance(transform.position, player.position); // Calculate the distance between the enemy and the player
            if (distanceToPlayer < AttackRange)
            {
                currentState = EnemyState.Attack; // Change state to Attack when the enemy is within stopping distance of the player
            }
     


    }
    void Attack()
    {
        // Implement attack behavior here
        Vector3 direction = player.position - transform.position;
        direction.y = 0f;// Keep the enemy on the same vertical level
        transform.rotation = Quaternion.LookRotation(direction);
        agent.isStopped = true; // Stop the enemy from moving
        //Attack Logic
        if(Time.time - lastAttackTime >= attackCoolDown)
        {
            Debug.Log("Attacked");
            lastAttackTime = Time.time; // Update the time of the last attack
        }
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer > AttackRange)
        {

            currentState = EnemyState.Chase;
        }

    }
    void BackToPost()
    {
        if(SpawnPoint != null)
        { 
            // Implement back to post behavior here
            agent.SetDestination(SpawnPoint.position);
            if (Vector3.Distance(transform.position, SpawnPoint.position) < 1.5f)
            {
                currentState = EnemyState.Idle; // Change state to Idle when the enemy reaches the spawn point
            }
         }
    }
    void Dead()
    {
        Destroy(gameObject); // Destroy the enemy game object when it is dead
    }
}
