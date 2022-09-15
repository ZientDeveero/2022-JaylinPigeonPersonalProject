using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public int lives;
    public TMP_Text livesText;
    public TMP_Text scoreText;
    public bool gameOver;
    public GameObject gameOverPanel;
    public int numberOfBricks;
    // Start is called before the first frame update
    void Start()
    {
        //set things a certain way at the start
        numberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        gameOverPanel.SetActive(false);
        lives = 3;
        score = 0;
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeLife()
    {
        lives -= 1;
        livesText.text = "Lives: " + lives;
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
    }
    public void ChangeScore()
    {
        score += 100;
        scoreText.text = "Score: " + score;
    }
    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
    }
    
    public void PlayAgain()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("I disappear, A ghost amist the combat, preparing to strike");
    }
    public void UpdateBrickNumber()
    {
        numberOfBricks--;
        if(numberOfBricks <= 0)
        {
            GameOver();
        }
    }

}
