using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent _navMeshAgent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start() => _navMeshAgent = GetComponent<NavMeshAgent>();

    // Update is called once per frame
    private void Update()
    {
        if (player != null)
        {
            _navMeshAgent.SetDestination(player.position);
        }
    }
}
