using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UiScoreManager : MonoBehaviour {

	public GameObject scoreText;

	public void Update() {
		this.scoreText.GetComponent<Text> ().text = Main.score.ToString();
	}

}
