using UnityEngine;

public class Obstacle : Collectible
{
    protected override void OnCollect(GameObject player)
    {
        // Handle obstacle collision with player
        AudioManager.instance.PlayAudio("event:/Death"); // Play death audio
        GameManager.Instance.GameOver(); // Trigger game over
    }
}
