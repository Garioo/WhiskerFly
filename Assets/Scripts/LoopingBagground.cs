using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    public float scrollSpeed = 2f; // Speed of the scrolling effect
    public float backgroundHeight; // Height of the background image

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        backgroundHeight = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, backgroundHeight);
        transform.position = startPosition + Vector3.down * newPosition;
    }
}
