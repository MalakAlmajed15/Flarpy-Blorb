using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public Text bestScoreText;

    void Start()
    {
        bestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("BestScore", 0).ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        if (playerScore > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", playerScore);
            PlayerPrefs.Save();
        }

        bestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("BestScore", 0).ToString();
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void quitGame(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }
}
