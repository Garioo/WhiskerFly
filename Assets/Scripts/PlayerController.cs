using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Balloon balloon;

    void Start()
    {
        balloon = GetComponent<Balloon>();
    }

    void Update()
    {
        // Any additional player-specific logic can go here
    }
}
