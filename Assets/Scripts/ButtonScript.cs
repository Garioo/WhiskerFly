using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public string startSceneName = "StartScene"; // Name of the start scene
    public string gameSceneName = "GameScene"; // Name of the game scene
    public void OnPlayAgainButtonClicked()
    {
        GameManager.Instance.RestartGame();
    }

    public void OnBackToStartButtonClicked()
    {
        Time.timeScale = 1; // Ensure the game time is running
        SceneManager.LoadScene(startSceneName);
    }
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
