using UnityEngine;

public class RandomObject : MonoBehaviour
{
    public GameObject prefabPickUp;
    // public GameObject prefabEnemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float x;
        float z;
        Vector3 position;

        for (int i = 0; i < 10; i++)
        {
            x = Random.Range(-18.0f, 18.0f);
            z = Random.Range(-18.0f, 18.0f);

            position = new(x, 0.5f, z);

            _ = Instantiate(prefabPickUp, position, Quaternion.identity);
        }

        // x = Random.Range(-18.0f, 18.0f);
        // z = Random.Range(-18.0f, 18.0f);

        // position = new(x, 0.5f, z);

        // _ = Instantiate(prefabEnemy, position, Quaternion.identity);

    }
}
