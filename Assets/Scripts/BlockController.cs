using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

	int blockHP = 1;
	Vector3 blockScale;

	void Start(){
		if (gameObject.tag=="Hard2Block") {
			blockHP = 2;
			blockScale = gameObject.transform.localScale;
		}
	}


	void OnCollisionEnter(Collision col) {
		if(col.gameObject.tag == "Ball"){
			blockHP -= 1;
			switch (blockHP) {
			case 0:
				Destroy (gameObject);
				break;
			case 1:
				gameObject.transform.localScale = new Vector3 (blockScale.x/1.8f, blockScale.y/1.8f, blockScale.z/1.8f);
				break;
			default:
				break;
			}
		}
	}
}
