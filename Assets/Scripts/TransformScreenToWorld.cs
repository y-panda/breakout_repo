using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformScreenToWorld : MonoBehaviour {

	public float baseWidth = 2160f;
	public float baseHeight = 3840f;
	float touchX;
	float touchY;
	Vector3 shootVec;

	public GameObject hogeObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

		if (Input.GetMouseButtonDown(0)) {
			Camera orthoCamera = gameObject.GetComponent<Camera> ();
			Vector3 screenPos = Input.mousePosition;
			//Debug.Log ("screenPos: "+screenPos);
			Vector3 worldPos = orthoCamera.ScreenToWorldPoint(screenPos);
			Debug.Log ("worldPos: "+worldPos);
			hogeObject.transform.position = worldPos; 
			//gameObject.transform.position = worldPos;
			//Debug.Log ("-----"+gameObject.transform.position);
		}
		//Debug.Log("( "+Input.mousePosition.x+" , "+Input.mousePosition.y+" )");


	}
}
