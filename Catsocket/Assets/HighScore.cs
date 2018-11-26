
using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HighScore : MonoBehaviour {

    public Text highScore;

	void Start ()
    {
        highScore.text = "Highscore: " + PlayerPrefs.GetInt("HighScore");
	}

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        highScore.text = "Highscore: 0";
    }

}
