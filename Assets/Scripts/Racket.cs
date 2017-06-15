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
		

		//gameObject.transform.position = WorldPointPos;
		gameObject.transform.position =
			new Vector3(slider.value, gameObject.transform.position.y, gameObject.transform.position.z);


	}
}
