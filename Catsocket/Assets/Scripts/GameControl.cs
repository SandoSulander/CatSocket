using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;         //A reference to our game control script so we can access it statically.
    public GameObject gameOverText;             //A reference to the object that displays the text which appears when the player dies.
    public GameObject newHighScoreText;         //A reference to the object that displays the text which appears when new high score is set.
    public Text scoreText;                      //A reference to the UI text component that displays the player's score.


    public int score = 0;                      //The player's score.
    private int killScore = 0;
    public bool gameOver = false;               //Is the game over?     
    public float scrollSpeed = -1.5f;


    void Awake()
    {

        //If we don't currently have a game control...
        if (instance == null)
        //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);
    }

    void Update()
    {
        //If the game is over and the player has pressed some input...
        if (gameOver == true && PauseMenu.GameIsPaused == false && Input.GetMouseButtonDown(0))
        {
            //...reload the current scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BirdScored()
    {
        //The character can't score if the game is over.
        if (gameOver)
        {
            return;
            }
        //If the game is not over, increase the score...
        score++;
        //...and adjust the score text.
        scoreText.text = "doges killed: " + killScore.ToString() + "      Score: " + score.ToString();
    }

    public void BirdScored2()
    {
        //The character can't score if the game is over.
        if (gameOver)
        {
            return;
        }
        //If the game is not over, increase the score...
        score+=5;
        killScore++;
        //...and adjust the score text.
        scoreText.text = "doges killed:" + killScore.ToString()+ "      Score: " + score.ToString();

    }



    public void BirdDied()
    {
        //Activate the game over text.
        gameOverText.SetActive(true);
        if (PlayerPrefs.GetInt("HighScore") < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
            newHighScoreText.SetActive(true);
            FindObjectOfType<AudioManager>().Play("KidsYay");
        }
        //Set the game to be over.
        gameOver = true;
    }

}
