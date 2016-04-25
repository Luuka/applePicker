using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour {

	//Game picker
	public Picker picker;

	/**
	 * @param Picker picker : Game Picker
	 * set the game Picker
	 */
	public void setPicker(Picker picker) {
		this.picker = picker;
	}

	// Update is called once per frame
	void Update () {
		float posY = this.transform.position.y;
		if (posY < -5) {
			this.picker.loseLife();
			Destroy(this.gameObject);
		}
	}
}
