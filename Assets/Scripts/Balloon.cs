using UnityEngine;

/// <summary>
/// Represents a balloon object in the game.
/// </summary>
public class Balloon : MonoBehaviour
{
    /// <summary>
    /// The speed at which the balloon tilts horizontally.
    /// </summary>
    public float tiltSpeed = 5f;

    private Rigidbody2D rb;
    private Camera mainCamera;
    private float halfWidth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        mainCamera = Camera.main;
        halfWidth = mainCamera.orthographicSize * Screen.width / Screen.height;
    }

    void FixedUpdate()
    {
        Vector3 tilt = Input.acceleration;
        rb.velocity = new Vector2(tilt.x * tiltSpeed, 0);
        float clampedX = Mathf.Clamp(transform.position.x, -halfWidth, halfWidth);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}

