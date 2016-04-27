using UnityEngine;
using System.Collections;

public class Picker : MonoBehaviour {

	//Lifes at the beggining of the game
	public int lifes = 3;

	// lifes bars
	public GameObject lifeBar1;
	public GameObject lifeBar2;
	public GameObject lifeBar3;

	// Picker move speed
	public float pickerSpeed;

	// score ui panel
	public GameObject uiScore;

	/**
	 * Move the picker to the right according to the pickerSpeed
	 */
	public void moveRight(){
		GameObject go = this.gameObject;
		if (go.transform.position.x < 5f) {
			Vector3 position = go.transform.position;
			go.transform.position = new Vector3 (position.x + pickerSpeed, position.y, position.z);
		}
	}

	/**
	 * Move the picker to the left according to the pickerSpeed
	 */
	public void moveLeft(){
		GameObject go = this.gameObject;
		if (go.transform.position.x > -5f) {
			Vector3 position = go.transform.position;
			go.transform.position = new Vector3 (position.x - pickerSpeed, position.y, position.z);
		}
	}

	/**
	 *  Decrease life count and remove the good life bar
	 */
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

	/**
	 * @param Collision col : Collision unity object
	 * Trigger when picker get an apple, increase score and destroy the apple
	 */
	void OnCollisionEnter(Collision col) {
		Destroy(col.gameObject);
		Main.score++;

	}

	/**
	 * reset the picker lifes, lifes bars and position at the origin
	 */
	public void reset() {
		this.lifes = 3;
		this.lifeBar1.SetActive(true);
		this.lifeBar2.SetActive(true);
		this.lifeBar3.SetActive(true);

		this.gameObject.transform.position = new Vector3 (0, -4f, 0);
	}
}
