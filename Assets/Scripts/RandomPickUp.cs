using UnityEngine;

public class RandomPickUp : MonoBehaviour
{
    public GameObject prefabPickUp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            float x = Random.Range(-18.0f, 18.0f);
            float z = Random.Range(-18.0f, 18.0f);

            Vector3 position = new(x, 0.5f, z);

            _ = Instantiate(prefabPickUp, position, Quaternion.identity);
        }

    }
}
