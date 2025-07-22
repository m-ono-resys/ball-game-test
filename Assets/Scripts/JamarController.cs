using UnityEngine;
using UnityEngine.AI;

public class JamarController : MonoBehaviour
{
    // 目的地を設定する間隔
    [SerializeField] float interval = 3.0f;

    // レイの長さ
    [SerializeField] float maxMoveDistance = 10f;

    // 経過時間
    float elapsedTime = 0f;

    // 歩く方向
    Vector3 walkDirection;

    NavMeshAgent agent;

    public GameObject okigamiPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ResetWalkParameters();
    }

    private void Update() => UpdateAgentMovement();

    private void ResetWalkParameters()
    {
        // パラメータを初期化
        elapsedTime = 0f;

        // ランダムの方向を作成
        var x = (Random.value * 2f) - 1f;
        var z = (Random.value * 2f) - 1f;

        walkDirection = new Vector3(x, 0f, z).normalized;
    }

    private void UpdateAgentMovement()
    {
        elapsedTime += Time.deltaTime;

        // 一定期間ごとに目的地を設定して値を初期化
        if (elapsedTime >= interval)
        {
            MoveTowardsTarget();
            ResetWalkParameters();
            PutOrigami();
        }
    }

    private void MoveTowardsTarget()
    {
        // レイの始点
        var sourcePos = transform.position;
        //sourcePos.y -= 1f;

        // レイの終点
        var targetPos = sourcePos + walkDirection * maxMoveDistance;

        // レイを投げる
        var blocked = NavMesh.Raycast(sourcePos, targetPos, out NavMeshHit hitInfo, NavMesh.AllAreas);

        if (blocked)
        {
            // ヒット地点を目的地にする
            agent.SetDestination(hitInfo.position);
        }
        else
        {
            // ターゲット位置を目的地にする。
            agent.SetDestination(targetPos);
        }

        // ラインを描画
        Debug.DrawLine(sourcePos, targetPos, blocked ? Color.red : Color.green, interval);
    }

    private void PutOrigami()
    {
        Vector3 position = new(transform.position.x, 0.1f, transform.position.z);
        _ = Instantiate(okigamiPrefab, position, Quaternion.identity);
    }
}
