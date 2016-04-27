using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

	//Apple quantity
	public int appleCount;

	//Delta time between two apples's launchs
	public static float timeBetweenTwoApples = 4f;

	public static void decreaseTimeBetweenTwoApples() {
		if (Tree.timeBetweenTwoApples > 1) {
			Tree.timeBetweenTwoApples -= 0.5f;
		}
	}

	// Use this for initialization
	void Start () {
		if (Tree.timeBetweenTwoApples >= 2) {
			this.appleCount = Random.Range (1, 10);
		} else {
			this.appleCount = Random.Range(1, 5);
		}
	}
	
}
