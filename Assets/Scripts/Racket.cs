using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Racket : MonoBehaviour {

	private Vector3 pos;
	private Vector3 WorldPointPos;

	public Slider slider;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*this.GetComponent<Rigidbody> ().AddForce (
			transform.right * Input.GetAxisRaw ("Horizontal") * accel,
			ForceMode.Impulse);*/
		/*pos = Input.mousePosition;
		WorldPointPos = Camera.main.ScreenToWorldPoint (pos);

		// 壁を突き抜けないようにx軸の移動範囲を限定
		if (WorldPointPos.x <= -2.1f) {
			WorldPointPos.x = -2.1f;

		} else if (WorldPointPos.x >= 2.1f) {
			WorldPointPos.x = 2.1f;
		}

		WorldPointPos.y = -3.0f;
		WorldPointPos.z = 0.0f;*/

		//gameObject.transform.position = WorldPointPos;
		gameObject.transform.position =
			new Vector3(slider.value, gameObject.transform.position.y, gameObject.transform.position.z);


	}
}
