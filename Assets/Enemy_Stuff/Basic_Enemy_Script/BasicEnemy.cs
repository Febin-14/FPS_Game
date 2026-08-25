    using UnityEngine;
    using UnityEngine.Rendering;

    public class BasicEnemy : EnemySystem
    {

    private bool isAttacking = false;
    private int ComboStep = 0;

    protected override void Idle()
        {
        }

        protected override void Patrol()
        {
            base.Patrol(); // Use the common patrol logic from EnemySystem

            // Basic enemy-specific patrol behavior
        }

protected override void Chase()
{
    if (!agent.pathPending)
    {
        agent.SetDestination(player.position);
    }

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

    protected override void Attack()
    {



        if (distanceToPlayer > attackRange)
        {
            ComboStep = 0;
            isAttacking = false;
            agent.isStopped = false;

            animator.CrossFade("Movement", 0.05f);
            ChangeState(EnemyState.Chase);
            return;
        }

        agent.isStopped = true;

        // Keep facing the player while attacking
        FacePlayer();

        if (isAttacking)
            return;

        isAttacking = true;

        switch (ComboStep)
        {
            case 0:
                animator.CrossFade("Attack_1", 0.05f);
                break;

            case 1:
                animator.CrossFade("Attack_2", 0.05f);
                break;

            case 2:
                animator.CrossFade("Attack_3", 0.05f);
                break;
        }
    }
    public  void DealDamage()
    {
        if(distanceToPlayer <= attackRange)
        {
            HealthManager.Instance.TakeDamage(damageAmt);
        }
    }
    public void ComboStepFinished()
    {
        if (distanceToPlayer > attackRange)
        {
            CancelCombo();
            animator.CrossFade("Movement", 0.05f);
            ChangeState(EnemyState.Chase);
            return;
        }

        ComboStep++;

        if (ComboStep >= 3)
        {
            ComboStep = 0;
        }

        isAttacking = false;
    }
    public void CancelCombo()
    {
        ComboStep = 0;
        isAttacking = false;
        agent.isStopped = false;
    }

}
