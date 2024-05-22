using UnityEngine;

public class Star : Collectible
{
    protected override void OnCollect(GameObject player)
    {
        // Handle star collection
        GameManager.Instance.CollectStar(); // Call the CollectStar method in the GameManager class
        AudioManager.instance.PlayAudio("event:/Star"); // Play the audio for collecting a star
        Destroy(gameObject); // Destroy the star game object
    }
}
