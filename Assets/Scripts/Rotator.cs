using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Update is called once per frame
    private void Update() => transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
}
