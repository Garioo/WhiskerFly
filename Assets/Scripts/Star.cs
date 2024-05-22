using UnityEngine;

public class Star : Collectible

{
    protected override void OnCollect(GameObject player)
    {
        // Handle star collection
        GameManager.Instance.CollectStar();
        Destroy(gameObject);
    }
}