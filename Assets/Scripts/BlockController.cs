using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

	public GameObject gameDirector;
	private ParticleSystem bursteffect;


	// Use this for initialization
	void Start () {
		bursteffect = this.GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.tag == "Treasure"){
			transform.Rotate(new Vector3(0, 0.5f, 0));
		}
	}

	void OnCollisionEnter(Collision col) {

		/*if(gameObject.tag == "Block"){
			//Handheld.Vibrate ();//振動
			//Destroy(gameObject);
		}else if(gameObject.tag == "Treasure"){
			Destroy(gameObject);
			gameDirector.GetComponent<GameDirector> ().GameClear ();
		}*/
		if(col.gameObject.tag == "Ball"){
			//bursteffect.Play ();
			Destroy(gameObject);

			gameDirector.GetComponent<GameDirector> ().GameClear ();
		}


	}
}
