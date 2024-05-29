/* 
--------------------------  
    GameManager.cs
Description: Script for controlling points and game state
--------------------------

Literature:

ChatGPT - Was used for the ReacquireUIReferences()
    
*/
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance of the GameManager
    public TextMeshProUGUI scoreText; // Reference to the UI text component for displaying the score
    public TextMeshProUGUI FinalScoreText; // Reference to the UI text component for displaying the final score
    public GameObject gameOverPanel; // Reference to the UI panel for displaying the game over screen
    public int score; // Current score of the game
    private Canvas canvas; // Reference to the UI canvas
    AudioManager audioManager; // Reference to the AudioManager script

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Ensure the GameManager persists across scenes
        }
        else
        {
            Destroy(gameObject);
            return; // Avoid further execution if this instance is destroyed
        }
    }

    void Start()
    {
        ReacquireUIReferences(); // Get references to UI elements
        InitializeGame(); // Initialize the game
    }

    void InitializeGame()
    {
        score = 0; // Reset the score
        UpdateScore(); // Update the score UI
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false); // Hide the game over panel
        }
        Time.timeScale = 1; // Ensure the game time is running
    }

    public void CollectStar()
    {
        score += 10; // Increase the score by 10 when a star is collected
        UpdateScore(); // Update the score UI
    }

    void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString(); // Convert score to string and update the score UI text
        }
        else
        {
            Debug.LogError("ScoreText not found!"); // Log an error if the score text component is not found
        }
    }

    public void GameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // Show the game over panel
            FinalScoreText.text =  score.ToString(); // Update the final score UI text
        }
        Time.timeScale = 0; // Pause the game
        AudioManager.instance.StopAudio("event:/GameScene"); // Stop the game scene audio
        AudioManager.instance.PlayAudio("event:/MainScene"); // Play the main scene audio
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Ensure time scale is reset before loading the scene
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the scene loaded event
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
        AudioManager.instance.StopAudio("event:/MainScene"); // Stop the main scene audio
        AudioManager.instance.PlayAudio("event:/GameScene"); // Play the game scene audio
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe from the scene loaded event
        ReacquireUIReferences(); // Reacquire UI references after scene reload
        InitializeGame(); // Initialize the game
    }

    void ReacquireUIReferences()
    {
        canvas = FindObjectOfType<Canvas>(); // Find the UI canvas in the scene
        if (canvas == null)
        {
            Debug.LogError("Canvas not found!"); // Log an error if the canvas is not found
            return;
        }

        FinalScoreText = canvas.transform.Find("GameOverPanel/FinalScoreText").GetComponent<TextMeshProUGUI>(); // Find the final score text component
        if (FinalScoreText == null)
        {
            Debug.LogError("FinalScoreText not found!"); // Log an error if the final score text component is not found
        }

        scoreText = canvas.GetComponentInChildren<TextMeshProUGUI>(); // Find the score text component
        if (scoreText == null)
        {
            Debug.LogError("ScoreText not found!"); // Log an error if the score text component is not found
        }

        Transform gameOverPanelTransform = canvas.transform.Find("GameOverPanel"); // Find the game over panel transform
        if (gameOverPanelTransform != null)
        {
            gameOverPanel = gameOverPanelTransform.gameObject; // Get the game over panel game object
        }
        else
        {
            Debug.LogError("GameOverPanel not found!"); // Log an error if the game over panel transform is not found
        }
    }
}
