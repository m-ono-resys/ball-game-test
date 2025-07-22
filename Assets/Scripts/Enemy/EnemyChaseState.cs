using UnityEngine;

public class EnemyChaseState : IEnemyState
{
    public void Enter(EnemyMovement context) => Debug.Log("簒奪者: 追いかける状態に切り替え");

    public void Update(EnemyMovement context) => context.navMeshAgent.SetDestination(context.player.position);
}
