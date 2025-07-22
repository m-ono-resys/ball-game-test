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
            Vector3 bestPosition = context.transform.position;
            float bestScore = -Mathf.Infinity;

            int sampleCount = 8; // 8方向
            float sampleRadius = context.fleeDistance;

            for (int i = 0; i < sampleCount; i++)
            {
                float angle = i * (360f / sampleCount);
                Vector3 dir = Quaternion.Euler(0, angle, 0) * Vector3.forward;
                Vector3 candidate = context.transform.position + (dir * sampleRadius);

                if (NavMesh.SamplePosition(candidate, out NavMeshHit hit, 2f, NavMesh.AllAreas))
                {
                    float score = Vector3.Distance(hit.position, context.player.position);
                    if (score > bestScore)
                    {
                        bestScore = score;
                        bestPosition = hit.position;
                    }
                }
            }

            context.navMeshAgent.SetDestination(bestPosition);
        }
        else
        {
            context.navMeshAgent.ResetPath();
        }
    }
}
