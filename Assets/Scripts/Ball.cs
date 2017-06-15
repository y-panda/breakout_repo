using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
	
	public GameObject gameClear;
	int speed = 4;
	public int blockCt = 20;
	Rigidbody rb;
	Vector3 v;
	Vector3 ballVelocity;
	public GameObject gameDirector;



	void Start(){
		rb = GetComponent<Rigidbody>();
		ballVelocity = gameObject.GetComponent<Rigidbody>().velocity;
		//BallShoot ();
	}


	void Update ()	{
		GetComponent<Rigidbody> ().velocity = GetComponent<Rigidbody> ().velocity.normalized * 5.0f;
		//Debug.Log (gameObject.GetComponent<Rigidbody>().velocity);
		//ブロックを全て壊した時
		if (blockCt == 0) {
			//ボールの動きを止める
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
			//GameClearScriptのWinメソッドを実行しGameClearの文字を表示
			gameClear.SendMessage ("Win");
			//クリックしてタイトル画面へ
			if (Input.GetMouseButtonDown (0)) {
				SceneManager.LoadScene("title");
			}
		}

	}

	void BallShoot(){
		//rb.AddForce((transform.up + transform.right) * speed, ForceMode.VelocityChange);
		//rb.AddForce((transform.up) * (1), ForceMode.VelocityChange);
	}


	void OnCollisionEnter (Collision col){
		//ブロックにぶつかるとブロックカウント-1
		if (col.gameObject.tag == "Block") {
			//blockCt -= 1;
		} else if (col.gameObject.tag == "Racket") {
			if (Mathf.Abs(ballVelocity.x)<0.5f) {
				ballVelocity = gameObject.GetComponent<Rigidbody>().velocity;
				ballVelocity.x += 0.1f;
				ballVelocity.x *= 5.0f;
				GetComponent<Rigidbody> ().velocity = ballVelocity;
			}

		} else if (col.gameObject.tag == "SideWall") {
			//壁に当たったときに上下に対する速度が遅すぎるとき
			if (Mathf.Abs(ballVelocity.y)<0.5f) {
				ballVelocity = gameObject.GetComponent<Rigidbody>().velocity;
				ballVelocity.y += 0.1f;
				ballVelocity.y *= 5.0f;
				GetComponent<Rigidbody> ().velocity = ballVelocity;
			}
		}

	}

}
