using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	
	public GameObject gameClear;
	int speed = 5;
	public int blockCt = 20;
	Rigidbody rb;
	Vector3 v;

	void Start(){
		rb = GetComponent<Rigidbody>();
		rb.AddForce((transform.up + transform.right) * speed, ForceMode.VelocityChange);
	}


	void Update ()	{
		//ブロックを全て壊した時
		if (blockCt == 0) {
			//ボールの動きを止める
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
			//GameClearScriptのWinメソッドを実行しGameClearの文字を表示
			gameClear.SendMessage ("Win");
			//クリックしてタイトル画面へ
			if (Input.GetMouseButtonDown (0)) {
				Application.LoadLevel ("title");
			}
		}

	}



	void OnCollisionEnter (Collision col){
		//ブロックにぶつかるとブロックカウント-1
		if (col.gameObject.tag == "Block") {
			blockCt -= 1;
		}
	}
}
