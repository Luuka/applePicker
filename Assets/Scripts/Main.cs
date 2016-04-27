using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	public static int score = 0;

	// Game over ui panel
	public GameObject gameOverUi;

	// Picker 
	public GameObject pickerGo;
	private Picker picker;

	// Tree
	public GameObject treeModel;
	private GameObject treeGo;
	private Tree tree;

	// Time between the last launch of an apple and now
	private float timeLaunchingApple = 0f;

	// Apple 
	public GameObject appleModel;
	
	// Use this for initialization
	void Start () {
		this.picker = pickerGo.GetComponent<Picker> ();
		addTree (); // Add the first tree to launch the game
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
		if (tree != null && tree.appleCount > 0 && this.timeLaunchingApple >= Tree.timeBetweenTwoApples) {
			this.launchApple();
			this.timeLaunchingApple = 0f;
		} else if(tree.appleCount == 0) {
			Tree.decreaseTimeBetweenTwoApples();
			this.addTree();
		}

	}

	/**
	 * Destroy the tree and display the game over ui panel
	 */
	void endGame() {
		Destroy (tree);
		gameOverUi.gameObject.SetActive (true);
	}

	/**
	 * Re-init game data, hide the gameOver ui panel and restart the game
	 */
	public void restartGame() {
		Main.score = 0;

		gameOverUi.gameObject.SetActive (false);

		Destroy (this.treeGo);
		this.picker.reset ();

		Tree.timeBetweenTwoApples = 4f;
		this.addTree ();
	}

	/**
	 * Instantiate an apple a the tree position, give it a force and decrease the apple count 
	 */
	void launchApple() {
		GameObject appleGo = GameObject.Instantiate(appleModel, new Vector3(treeGo.transform.position.x, treeGo.transform.position.y, 0f), Quaternion.identity) as GameObject;
		appleGo.GetComponent<Apple> ().setPicker (picker);
		float randomX = Random.Range (-100f, 100f);
		float randomY = Random.Range (-100f, 100f);
		appleGo.GetComponent<Rigidbody> ().AddForce (new Vector3 (randomX,randomY, 0));
		tree.appleCount--;
	}


	/**
	 * Instantiate a tree at a random position
	 */
	void addTree() {
		int randomX = Random.Range (-5, 5);

		if (treeGo != null) {
			Destroy(treeGo);
		}

		treeGo = GameObject.Instantiate (treeModel, new Vector3(randomX, 3.5f,-2f), Quaternion.identity) as GameObject;
		tree = treeGo.GetComponent<Tree> ();
	}
}
