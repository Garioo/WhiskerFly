using UnityEngine;
public class Obstacle : Collectible
{
    protected override void OnCollect(GameObject player)
    {
        // Handle obstacle collision with player
        GameManager.Instance.GameOver();
    }
}
