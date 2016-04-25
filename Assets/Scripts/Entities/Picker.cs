using UnityEngine;
using System.Collections;

public class Picker : MonoBehaviour {

	public int lifes = 3;
	public GameObject lifeBar1;
	public GameObject lifeBar2;
	public GameObject lifeBar3;

	public float pickerSpeed;

	public GameObject uiScore;

	public void moveRight(){
		GameObject go = this.gameObject;
		if (go.transform.position.x < 5f) {
			Vector3 position = go.transform.position;
			go.transform.position = new Vector3 (position.x + pickerSpeed, position.y, position.z);
		}
	}

	public void moveLeft(){
		GameObject go = this.gameObject;
		if (go.transform.position.x > -5f) {
			Vector3 position = go.transform.position;
			go.transform.position = new Vector3 (position.x - pickerSpeed, position.y, position.z);
		}
	}

	public void loseLife() {

		switch (this.lifes) {
		case 1:
			lifeBar1.SetActive(false);
			break;
		case 2:
			lifeBar2.SetActive(false);
			break;
		case 3:
			lifeBar3.SetActive(false);
			break;
		}

		--this.lifes;
	}

	void OnCollisionEnter(Collision col) {
		Destroy(col.gameObject);
		Main.score++;
	}

	public void reset() {
		this.lifes = 3;
		this.lifeBar1.SetActive(true);
		this.lifeBar2.SetActive(true);
		this.lifeBar3.SetActive(true);

		this.gameObject.transform.position = new Vector3 (0, -4f, 0);

	}
}
