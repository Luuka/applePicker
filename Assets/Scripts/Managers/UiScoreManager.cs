using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UiScoreManager : MonoBehaviour {

	// UI score text
	public GameObject scoreText;

	// Update is called once per fra
	public void Update() {
		this.scoreText.GetComponent<Text> ().text = Main.score.ToString();
	}

}
