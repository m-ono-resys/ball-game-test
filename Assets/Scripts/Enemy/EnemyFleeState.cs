using UnityEngine;
using UnityEngine.AI;

public class EnemyFleeState : IEnemyState
{
    public void Enter(EnemyMovement context) => Debug.Log("簒奪者: 逃げる状態に切り替え");
    public void Update(EnemyMovement context)
    {
        float distanceToPlayer = Vector3.Distance(context.transform.position, context.player.position);

        if (distanceToPlayer < context.detectionRange)
        {
            Vector3 fleeDirection = (context.transform.position - context.player.position).normalized;
            Vector3 targetPosition = context.transform.position + (fleeDirection * context.fleeDistance);
            if (NavMesh.SamplePosition(targetPosition, out NavMeshHit hit, 2f, NavMesh.AllAreas))
            {
                _ = context.navMeshAgent.SetDestination(hit.position);
            }
        }
        else
        {
            context.navMeshAgent.ResetPath();
        }
    }
}
