using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Explosion : MonoBehaviour {

	private List<string> myList = new List<string>();
	public bool explodedIs;
	Rigidbody rb;

	void Start(){
		explodedIs = false;
	}

	void OnTriggerStay(Collider col) {
		if (explodedIs && col.tag == "Block") {
			if (!myList.Contains (col.name)) {
				Debug.Log (col);
				myList.Add (col.name);
				col.gameObject.transform.localScale = new Vector3 (col.gameObject.transform.localScale.x / 2f, col.gameObject.transform.localScale.y / 2f, col.gameObject.transform.localScale.z / 2f);
				rb = col.gameObject.GetComponent<Rigidbody> ();
				rb.mass = rb.mass / 100f;
			} else {
				Destroy (gameObject);
			}
		}
	}
}
