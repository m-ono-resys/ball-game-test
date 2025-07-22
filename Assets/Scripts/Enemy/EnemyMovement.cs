using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent navMeshAgent;
    public float detectionRange = 10f;  // プレイヤーを意識する距離

    [Range(5, 30)]
    public float fleeDistance = 5f;     // 逃げる距離
    public float chaseDistance = 2f;    // 奪うために近づく距離
    public bool shouldChase = true;          // 近づくか逃げるか

    private IEnemyState _currentState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetState(new EnemyFleeState());
    }

    // Update is called once per frame
    private void Update()
    {
        if (player != null)
        {
            _currentState?.Update(this);
        }
    }

    public void SetState(IEnemyState state)
    {
        _currentState = state;
        _currentState.Enter(this);
    }
}
