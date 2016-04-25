using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

	//Apple quantity
	public int appleCount;

	//Delta time between two apples's launchs
	public float timeBetweenTwoApples;

	// Use this for initialization
	void Start () {
		this.appleCount = Random.Range(1, 10);
		this.timeBetweenTwoApples = Random.Range (0.5f, 2f);
	}
	
}
