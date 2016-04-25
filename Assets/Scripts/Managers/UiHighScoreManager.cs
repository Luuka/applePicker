using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UiHighScoreManager : MonoBehaviour {

	public GameObject highScoreText;

	// Use this for initialization
	void Start () {
		if (!PlayerPrefs.HasKey ("HighScore")) {
			PlayerPrefs.SetInt("HighScore", 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		int highScore = PlayerPrefs.GetInt ("HighScore");

		if (highScore < Main.score) {
			PlayerPrefs.SetInt("HighScore", Main.score);
			highScore = PlayerPrefs.GetInt ("HighScore");
		}


		this.highScoreText.GetComponent<Text> ().text = highScore.ToString();
	}
}
