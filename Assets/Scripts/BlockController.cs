using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

	public GameObject gameDirector;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col) {

		if(gameObject.tag == "Block"){
			Destroy(gameObject);
		}else if(gameObject.tag == "Treasure"){
			Destroy(gameObject);
			gameDirector.GetComponent<GameDirector> ().GameClear ();
		}



	}
}
