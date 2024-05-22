using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI FinalScoreText;
    public GameObject gameOverPanel;
    public int score;
    private Canvas canvas;

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
        ReacquireUIReferences();
        InitializeGame();
    }

    void InitializeGame()
    {
        score = 0;
        UpdateScore();
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        Time.timeScale = 1; // Ensure the game time is running
    }

    public void CollectStar()
    {
        score += 10;
        UpdateScore();
    }

    void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString(); // Convert score to string
        }
        else
        {
            Debug.LogError("ScoreText not found!");
        }
    }

    public void GameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            FinalScoreText.text =  score.ToString();
        }
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Ensure time scale is reset before loading the scene
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        ReacquireUIReferences(); // Reacquire UI references after scene reload
        InitializeGame();
    }

    void ReacquireUIReferences()
    {
        canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            Debug.LogError("Canvas not found!");
            return;
        }

        FinalScoreText = canvas.transform.Find("GameOverPanel/FinalScoreText").GetComponent<TextMeshProUGUI>();
        if (FinalScoreText == null)
        {
            Debug.LogError("FinalScoreText not found!");
        }

        scoreText = canvas.GetComponentInChildren<TextMeshProUGUI>();
        if (scoreText == null)
        {
            Debug.LogError("ScoreText not found!");
        }

        Transform gameOverPanelTransform = canvas.transform.Find("GameOverPanel");
        if (gameOverPanelTransform != null)
        {
            gameOverPanel = gameOverPanelTransform.gameObject;
        }
        else
        {
            Debug.LogError("GameOverPanel not found!");
        }
    }
}
