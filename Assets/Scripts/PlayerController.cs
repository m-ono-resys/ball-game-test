using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private float movementX;
    private float movementY;

    public float speed = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var accelerometer = Accelerometer.current;

        if (accelerometer == null || !accelerometer.enabled)
        {
            Debug.LogWarning("Accelerometer is not available or not enabled.");
            return;
        }

        InputSystem.EnableDevice(accelerometer);

        var enabled = accelerometer.enabled;

        movementX = accelerometer.acceleration.ReadValue().x;
        movementY = accelerometer.acceleration.ReadValue().y;
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    //private void Update()
    //{
    //    movementX = Input.acceleration.x;
    //    movementY = Input.acceleration.y;
    //}

    //void OnMove(InputValue movementValue)
    //{
    //    Vector2 movementVector = movementValue.Get<Vector2>();
    //    movementX = movementVector.x;
    //    movementY = movementVector.y;
    //}
}
