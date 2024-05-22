using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float tiltSpeed = 5f; // Horizontal speed based on tilt
    private Rigidbody2D rb;
    private Camera mainCamera;
    private float halfWidth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Ensure gravity is disabled
        mainCamera = Camera.main;
        halfWidth = mainCamera.orthographicSize * Screen.width / Screen.height;
    }

    void FixedUpdate()
    {
        // Get the device tilt
        Vector3 tilt = Input.acceleration;

        // Apply horizontal movement based on tilt (invert the x-axis)
        rb.velocity = new Vector2(tilt.x * tiltSpeed, 0);

        // Clamp the balloon's position within the camera's boundaries
        float clampedX = Mathf.Clamp(transform.position.x, -halfWidth, halfWidth);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}

