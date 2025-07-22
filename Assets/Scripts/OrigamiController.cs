using UnityEngine;

public class OrigamiController : MonoBehaviour
{
    public float timer = 3.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start() => Destroy(gameObject, timer);
}
