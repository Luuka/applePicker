using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	public static int score = 0;

	public GameObject gameOverUi;

	public GameObject pickerGo;
	private Picker picker;

	public GameObject treeModel;
	private GameObject treeGo;
	private Tree tree;
	
	private float timeLaunchingApple = 0f;

	public GameObject appleModel;
	
	// Use this for initialization
	void Start () {
		this.picker = pickerGo.GetComponent<Picker> ();
		addTree ();
		gameOverUi.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		if (picker.lifes > 0) {
			if (Input.GetKey (KeyCode.RightArrow)) {
				picker.moveRight ();
			} else if (Input.GetKey (KeyCode.LeftArrow)) {
				picker.moveLeft ();
			}
		} else {
			this.endGame();
		}

		this.timeLaunchingApple += Time.deltaTime;

		//It stay apple on the tree
		if (tree != null && tree.appleCount > 0 && this.timeLaunchingApple >= tree.timeBetweenTwoApples) {
			this.launchApple();
			this.timeLaunchingApple = 0f;
		} else if(tree.appleCount == 0) {
			this.addTree();
		}

	}

	void endGame() {
		Destroy (tree);
		gameOverUi.gameObject.SetActive (true);
	}

	public void restartGame() {
		Main.score = 0;
		Destroy (this.treeGo);
		this.picker.reset ();
		this.addTree ();
		gameOverUi.gameObject.SetActive (false);
	}

	void launchApple() {
		GameObject appleGo = GameObject.Instantiate(appleModel, new Vector3(treeGo.transform.position.x, treeGo.transform.position.y, 0f), Quaternion.identity) as GameObject;
		appleGo.GetComponent<Apple> ().setPicker (picker);
		float randomX = Random.Range (-100f, 100f);
		float randomY = Random.Range (-100f, 100f);
		//randomX = -100f;
		//randomY = -100f;
		appleGo.GetComponent<Rigidbody> ().AddForce (new Vector3 (randomX,randomY, 0));
		tree.appleCount--;
	}

	void addTree() {
		int randomX = Random.Range (-5, 5);
		//randomX = -5;

		if (treeGo != null) {
			Destroy(treeGo);
		}

		treeGo = GameObject.Instantiate (treeModel, new Vector3(randomX, 3.5f,-2f), Quaternion.identity) as GameObject;
		tree = treeGo.GetComponent<Tree> ();
	}
}
