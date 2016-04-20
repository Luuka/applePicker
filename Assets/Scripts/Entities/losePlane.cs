using UnityEngine;
using System.Collections;

public class losePlane : MonoBehaviour {
	
	void OnCollisionEnter(Collision col) {
		Debug.Log ("collision");
		Destroy(col.gameObject);
	}
}
