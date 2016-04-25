using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour {

	public Picker picker;

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
