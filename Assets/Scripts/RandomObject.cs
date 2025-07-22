using UnityEngine;

public class RandomObject : MonoBehaviour
{
    public int pickUpBoxCount;

    public int dynamicBoxCount;

    public GameObject prefabPickUp;
    public GameObject prefabDynamicBox;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        for (int i = 0; i < pickUpBoxCount; i++)
        {
            MakeObject(prefabPickUp);
        }

        for (int i = 0; i < dynamicBoxCount; i++)
        {
            MakeObject(prefabDynamicBox);
        }
    }

    private void MakeObject(GameObject gameObject)
    {
        float x = Random.Range(-18.0f, 18.0f);
        float z = Random.Range(-18.0f, 18.0f);
        Vector3 position = new(x, 0.5f, z);
        _ = Instantiate(gameObject, position, Quaternion.identity);
    }
}
