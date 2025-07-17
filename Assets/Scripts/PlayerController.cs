using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;

    private float _movementX;
    private float _movementY;

    public float speed = 0;

    public TextMeshProUGUI countText;

    private int _count;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _count = 0;
        SetCountText();
    }

    private void FixedUpdate()
    {
        // var accelerometer = Accelerometer.current;

        // if (accelerometer == null || !accelerometer.enabled)
        // {
        //     Debug.LogWarning("Accelerometer is not available or not enabled.");
        //     return;
        // }

        // InputSystem.EnableDevice(accelerometer);

        // var enabled = accelerometer.enabled;

        // movementX = accelerometer.acceleration.ReadValue().x;
        // movementY = accelerometer.acceleration.ReadValue().y;
        Vector3 movement = new(_movementX, 0.0f, _movementY);
        _rb.AddForce(movement * speed);
    }

    // private void Update()
    // {
    //    movementX = Input.acceleration.x;
    //    movementY = Input.acceleration.y;
    // }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        _movementX = movementVector.x;
        _movementY = movementVector.y;
    }

    private void SetCountText()
   {
        int remind = 10 - _count;
        countText.text = "あと " + remind.ToString() + "こ";
   }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            _count++;
            SetCountText();
        }
    }
}
