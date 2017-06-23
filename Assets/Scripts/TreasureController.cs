﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureController : MonoBehaviour {

	public GameObject gameDirector;

	void Update () {
		transform.Rotate(new Vector3(0, 0.5f, 0));
	}

	void OnCollisionEnter(Collision col) {
		if(col.gameObject.tag == "Ball"){
			Destroy(gameObject);
			gameDirector.GetComponent<GameDirector> ().GameClear ();
		}
	}
}
