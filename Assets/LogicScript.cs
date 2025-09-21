using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public bool isGameOver = false;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore+=scoreToAdd;
        scoreText.text = playerScore.ToString();
    }
  
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void gameOver()
    {
        if (!isGameOver) // first time only
        {
            isGameOver = true;
            gameOverScreen.SetActive(true);
            audioManager.PlaySFX(audioManager.death);
        }
    }
}
