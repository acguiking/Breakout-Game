using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // Library needed for text
using UnityEngine.SceneManagement; // Library needed to access scenes

public class GameManager : MonoBehaviour
{

    // lives and scores variables
    public int lives;
    public int score;

    // variables needed to count each brick
    public int scarletBricks;
    public int grayBricks;
    public int totalBrickCount;

    // checks to see if it is game over
    public bool gameOver;


    

    // link to game over panel
    public GameObject gameOverPanel;

    // link to win panel
    public GameObject gameWinPanel;

    // text variables
    public Text scoreText;
    public Text livesText;
    public Text scarletText;
    public Text grayText;

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        scarletText.text = "Scarlet Bricks Remaining: " + scarletBricks;
        grayText.text = "Gray Bricks Remaining: " + grayBricks;
        scarletBricks = GameObject.FindGameObjectsWithTag("Scarlet Brick").Length;
        grayBricks = GameObject.FindGameObjectsWithTag("Gray Brick").Length;
        totalBrickCount = scarletBricks + grayBricks;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public needed for ball script to access this
    // 
    public void UpdateLives(int changeInLives) {
        lives += changeInLives;

        //Check for no lives left and trigger the end of the game
        if(lives <= 0){
            lives = 0;
            GameOver();
        }

        livesText.text = "Lives: " + lives;
    }

    public void UpdateScore(int points){
        score += points;

        scoreText.text = "Score: " + score;
    }

    public void UpdateScarlet(int scarletRemaining){
        scarletBricks += scarletRemaining;

        scarletText.text = "Scarlet Bricks Remaining: " + scarletBricks;
    }

    public void UpdateGray(int grayRemaining){
        grayBricks += grayRemaining;

        grayText.text = "Gray Bricks Remaining: " + grayBricks;
    }

    // Separate panels for game win or not
    void GameOver(){
        gameOver = true;
        gameOverPanel.SetActive(true);

    }

    void GameWin(){
        gameOver = true;
        gameWinPanel.SetActive(true);
    }

    public void UpdateNumberOfBricks(){
        totalBrickCount--;
        if(totalBrickCount <= 0){
            GameWin();
        }
    }

    public void PlayAgain(){
        SceneManager.LoadScene("Main");
    }

    public void Quit(){
        Application.Quit();
        Debug.Log ("Game Quit");
    }
}
