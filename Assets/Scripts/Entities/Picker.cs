using UnityEngine;
using System.Collections;

public class Picker : MonoBehaviour {

	public int lifes = 3;
	public GameObject lifeBar1;
	public GameObject lifeBar2;
	public GameObject lifeBar3;

	public void moveRight(){
		GameObject go = this.gameObject;
		Vector3 position = go.transform.position;
		go.transform.position = new Vector3 (position.x + 0.1f, position.y, position.z);
	}

	public void moveLeft(){
		GameObject go = this.gameObject;
		Vector3 position = go.transform.position;
		go.transform.position = new Vector3 (position.x - 0.1f, position.y, position.z);
	}

	public void loseLife() {

		switch (this.lifes) {
		case 1:
			lifeBar1.GetComponent<Renderer>().enabled = false;
			break;
		case 2:
			lifeBar2.GetComponent<Renderer>().enabled = false;
			break;
		case 3:
			lifeBar3.GetComponent<Renderer>().enabled = false;
			break;
		}

		--this.lifes;
	}

	void OnCollisionEnter(Collision col) {
		Debug.Log ("collision");
		Destroy(col.gameObject);
	}
}
