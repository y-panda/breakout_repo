using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {
	
	void OnCollisionEnter(Collision col) {
		if(col.gameObject.tag == "Ball"){
			Destroy(gameObject);
		}
	}
}
