using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public string startSceneName = "StartScene"; // Name of the start scene
    public string gameSceneName = "GameScene"; // Name of the game scene

    // Called when the "Play Again" button is clicked
    public void OnPlayAgainButtonClicked()
    {
        GameManager.Instance.RestartGame(); // Restart the game using the GameManager instance
    }

    // Called when the "Back to Start" button is clicked
    public void OnBackToStartButtonClicked()
    {
        Time.timeScale = 1; // Ensure the game time is running
        SceneManager.LoadScene(startSceneName); // Load the start scene
    }

    // Called when the "Start" button is clicked
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene(gameSceneName); // Load the game scene
    }
}
