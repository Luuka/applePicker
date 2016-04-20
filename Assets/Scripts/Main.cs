using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	public GameObject pickerModel;
	private GameObject pickerGo;
	private Picker picker;

	public GameObject treeModel;
	private GameObject treeGo;
	private Tree tree;

	private float timeLaunchingApple = 0f;

	public GameObject appleModel;
	
	// Use this for initialization
	void Start () {
		pickerGo = GameObject.Instantiate (pickerModel, new Vector3 (0, -4f, 0), Quaternion.identity) as GameObject;
		picker = pickerGo.GetComponent<Picker> ();
		addTree ();
	}
	
	// Update is called once per frame
	void Update () {

		if (picker.lifes > 0) {
			if (Input.GetKey (KeyCode.RightArrow)) {
				picker.moveRight();
			} else if (Input.GetKey (KeyCode.LeftArrow)) {
				picker.moveLeft();
			}
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

	void launchApple() {
		GameObject appleGo = GameObject.Instantiate(appleModel, treeGo.transform.position, Quaternion.identity) as GameObject;
		appleGo.GetComponent<Rigidbody> ().AddForce (new Vector3 (Random.Range (-250f,250f), Random.Range (-250f,250f), 0));
		tree.appleCount--;
	}

	void addTree() {
		int randomX = Random.Range (-5, 5);

		if (treeGo != null) {
			Destroy(treeGo);
		}

		treeGo = GameObject.Instantiate (treeModel, new Vector3(randomX, 3.5f,0), Quaternion.identity) as GameObject;
		tree = treeGo.GetComponent<Tree> ();
	}
}
