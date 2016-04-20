using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

	public int appleCount;
	public float timeBetweenTwoApples;

	void Start () {
		this.appleCount = Random.Range(1, 10);
		this.timeBetweenTwoApples = Random.Range (0.5f, 2f);
	}
	
}
