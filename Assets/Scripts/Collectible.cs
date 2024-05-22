using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    protected abstract void OnCollect(GameObject player);

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollect(other.gameObject);
        }
    }
}


