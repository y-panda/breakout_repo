using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformScreenToWorld : MonoBehaviour {
	//タッチされたスクリーン座標から、目標場所のワールド座標計算

	public float baseWidth = 2160f;
	public float baseHeight = 3840f;

	public GameObject searchLight;

	Vector3 shootVec;

	Camera orthoCamera;

	public GameObject orthoObject; //orthographicのカメラから見てる。画面中央(0,0）
	public GameObject shootObject; //発射する玉


	//発射ベクトル計算
	public Vector3 CalcShootVec(GameObject tamaObj){
		orthoCamera = gameObject.GetComponent<Camera> ();
		Vector3 screenPos = Input.mousePosition;

		Vector3 worldPos = orthoCamera.ScreenToWorldPoint(screenPos);
		//Debug.Log ("orthoObjectから見た目標座標(worldPos): "+worldPos);

		orthoObject.transform.position = worldPos; //目印移動
		//Debug.Log ("-----"+gameObject.transform.position);
		shootVec.x = worldPos.x-tamaObj.transform.position.x;
		shootVec.y = worldPos.y-tamaObj.transform.position.y;
		shootVec.z = worldPos.z; //1.2
		//Debug.Log ("発射物から見た目標座標: "+shootVec);

		float dx = shootVec.x;
		float dy = shootVec.y;
		float rad = Mathf.Atan2 (dy, dx);
		//Debug.Log ("角度: "+rad*Mathf.Rad2Deg);

		searchLight.transform.rotation = Quaternion.Euler(0, 0, rad*Mathf.Rad2Deg-90);

		return shootVec;
	}

}
