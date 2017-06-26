using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Explosion : MonoBehaviour {

	private List<string> myList = new List<string>();

	void OnTriggerStay(Collider col) {
		if (col.tag == "Block") {
			if (!myList.Contains (col.name)) {
				Debug.Log (col);
				myList.Add (col.name);
				col.gameObject.transform.localScale = new Vector3 (col.gameObject.transform.localScale.x / 2f, col.gameObject.transform.localScale.y / 2f, col.gameObject.transform.localScale.z / 2f);
			} 
		}
	}
}
