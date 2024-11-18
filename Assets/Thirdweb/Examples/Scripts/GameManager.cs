using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Text scoreText;
    public GameObject gameOverCanvas;

    public Player player;

    private int score;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        Application.targetFrameRate = 60;
        Pause();
      
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        gameOverCanvas.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;
        player.transform.position = new Vector3(-1.5f, 1f, 0f);

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Pause();
        //Debug.Log("Game Over");
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
