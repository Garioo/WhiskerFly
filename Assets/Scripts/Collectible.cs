using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    // Called when the collectible is collected by the player.
    protected abstract void OnCollect(GameObject player);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollect(other.gameObject);
        }
    }
}


