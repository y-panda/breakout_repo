using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformScreenToWorld : MonoBehaviour {

	public float baseWidth = 2160f;
	public float baseHeight = 3840f;
	float touchX;
	float touchY;
	Vector3 shootVec;
	Rigidbody rb;

	public GameObject orthoObject; //orthographicのカメラから見てる。画面中央(0,0）
	public GameObject shootObject; //発射する玉

	// Use this for initialization
	void Start () {
		rb = shootObject.GetComponent<Rigidbody>();
		Debug.Log ("orthoObjectから見たshootObject座標"+shootObject.transform.position); 
	}
	
	// Update is called once per frame
	void Update () {
		

		if (Input.GetMouseButtonDown(0)) {
			Camera orthoCamera = gameObject.GetComponent<Camera> ();
			Vector3 screenPos = Input.mousePosition;
			//Debug.Log ("screenPos: "+screenPos);

			Vector3 worldPos = orthoCamera.ScreenToWorldPoint(screenPos);
			Debug.Log ("orthoObjectから見た目標座標(worldPos): "+worldPos);

			orthoObject.transform.position = worldPos; //目印移動
			//Debug.Log ("-----"+gameObject.transform.position);
			shootVec.x = worldPos.x-shootObject.transform.position.x;
			shootVec.y = worldPos.y-shootObject.transform.position.y;
			shootVec.z = worldPos.z;
			Debug.Log ("shootObjectから見た目標座標: "+shootVec);

			rb.AddForce((shootVec) * (1f), ForceMode.VelocityChange);
		}
		//Debug.Log("( "+Input.mousePosition.x+" , "+Input.mousePosition.y+" )");


	}
}
