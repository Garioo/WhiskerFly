/* 
--------------------------  
    LoopingBackground.cs
Description: Script for creating a looping background effect by continuously scrolling an image vertically.
--------------------------

Literature:
    * Unity Youtube Tutorial by Dani - Infinite Background Scrolling:
        [Link](https://www.youtube.com/watch?v=zit45k6CUMk&ab_channel=Dani)
*/

using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    public float scrollSpeed = 2f; // Speed of the scrolling effect
    public float backgroundHeight; // Height of the background image

    private Vector3 startPosition; // Initial position of the background

    void Start()
    {
        // Save the initial position of the background
        startPosition = transform.position;
        
        // Get the height of the background image from the SpriteRenderer component
        backgroundHeight = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        // Calculate the new position using the Repeat function to create a looping effect
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, backgroundHeight);
        
        // Update the position of the background to create the scrolling effect
        transform.position = startPosition + Vector3.down * newPosition;
    }
}
