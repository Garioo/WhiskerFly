/* 
--------------------------  
    Balloon.cs
Description: Script for tilting an object based on device acceleration
--------------------------

Literature:
    * Unity Youtube Tutorial by Alexander Zotov- Accelerometer and Gyroscope:
        [Link](https://www.youtube.com/watch?v=wpSm2O2LIRM&t=9s&ab_channel=AlexanderZotov)
    * Stack overflow forum - Camera orthographic size certain width
        [Link] (https://stackoverflow.com/questions/69071921/camera-orthographic-size-certain-width)
*/

using UnityEngine;
public class Balloon : MonoBehaviour
{
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
        Vector2 tilt = Input.acceleration;
        rb.velocity = new Vector2(tilt.x * tiltSpeed, 0);
        float clampedX = Mathf.Clamp(transform.position.x, -halfWidth, halfWidth);
        transform.position = new Vector2(clampedX, transform.position.y);
    }
}

