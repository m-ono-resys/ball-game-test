using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent _navMeshAgent;
    public float detectionRange = 10f;  // プレイヤーを意識する距離

    [SerializeField, Range(5, 30)]
    private float _fleeDistance = 5f;     // 逃げる距離
    public float chaseDistance = 2f;    // 奪うために近づく距離
    public bool shouldChase = true;          // 近づくか逃げるか

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start() => _navMeshAgent = GetComponent<NavMeshAgent>();

    // Update is called once per frame
    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (shouldChase)
            {
                Debug.Log("追いかけます");
                _ = _navMeshAgent.SetDestination(player.position);
            }
            else
            {
                if (distanceToPlayer < detectionRange)
                {
                    Debug.Log("逃げます");
                    Vector3 fleeDirection = (transform.position - player.position).normalized;
                    Vector3 targetPosition = transform.position + (fleeDirection * _fleeDistance);
                    if (NavMesh.SamplePosition(targetPosition, out NavMeshHit hit, 2f, NavMesh.AllAreas))
                    {
                        _ = _navMeshAgent.SetDestination(hit.position);
                    }
                }
                else
                {
                    _navMeshAgent.ResetPath();
                }
            }
        }
    }
}
