using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Racket : MonoBehaviour {

	private Vector3 pos;
	private Vector3 WorldPointPos;

	public Slider slider;
	float startPos = 0f;

	public bool moveModeIs;

	public GameObject orthoObject;


	// Use this for initialization
	void Start () {
		moveModeIs = false;
	}


	void Update () {		
		if (moveModeIs) {
			WorldPointPos = orthoObject.GetComponent<TransformScreenToWorld> ().CalcCarPos (gameObject);

			// 壁を突き抜けないようにx軸の移動範囲を限定
			if (WorldPointPos.x <= -2.2f) {
				WorldPointPos.x = -2.2f;
			} else if (WorldPointPos.x >= 2.2f) {
				WorldPointPos.x = 2.2f;
			}

			//y軸とz軸は固定
			WorldPointPos.y = -4.5f;
			WorldPointPos.z = 1.21f;

			// ワールド座標をPlayer位置へ変換
			gameObject.transform.position = WorldPointPos;
			//gameObject.transform.position = pos;
		}


	}

	//スライダーの固定位置を決定する
	public void SetPos(){
		startPos = gameObject.transform.position.x;
	}
}
