using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	
	int speed = 5;

	Rigidbody rb;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		//右上にボールを動かす
		rb.AddForce((transform.up + transform.right) * speed, ForceMode.VelocityChange);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
