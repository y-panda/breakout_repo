using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
	
	public GameObject gameClear;
	float maxSpeed = 4f;
	public int blockCt = 20;
	Rigidbody rb;
	Vector3 ballVelocity;


	public float baseWidth = 2160f;
	public float baseHeight = 3840f;
	Vector3 shootVec;

	GameObject orthoObject;
	bool shootIdlingIs = true;

	GameObject lightParent;
	GameObject racket;

	void Start(){
		//racket = GameObject.Find ("Racket");
		racket = GameObject.Find ("bar");
		orthoObject = GameObject.Find ("GameObject");
		// サーチライトの電気をつける
		lightParent = GameObject.Find ("LightParent");
		lightParent.transform.position = new Vector3(transform.position.x, transform.position.y, 1f);
		lightParent.transform.FindChild ("SearchLight").gameObject.GetComponent<Light> ().spotAngle = 21;

		rb = GetComponent<Rigidbody>();
		ballVelocity = gameObject.GetComponent<Rigidbody>().velocity;
		BallShoot ();
	}


	void Update ()	{
		//タッチしてる間、角度計算する
		if (Input.GetMouseButton (0)&&shootIdlingIs) {
			racket.GetComponent<Racket> ().moveModeIs = false;
			//発射角度を計算
			shootVec = orthoObject.GetComponent<TransformScreenToWorld> ().CalcShootVec (gameObject);

		}
		//指離したら発射
		if (Input.GetMouseButtonUp (0)&&shootIdlingIs&&shootVec.y>0f) {
			shootIdlingIs = false;
			racket.GetComponent<Racket> ().moveModeIs = true; //ラケットの操作可能にする
			//サーチライトを消す
			lightParent.transform.FindChild ("SearchLight").gameObject.GetComponent<Light> ().spotAngle = 0;

			BallShoot ();				
		}

		//速度を正規化
		GetComponent<Rigidbody> ().velocity = GetComponent<Rigidbody> ().velocity.normalized * maxSpeed;

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
		rb.AddForce((shootVec) * (1f), ForceMode.VelocityChange);
		//rb.AddForce((transform.right) * (1f), ForceMode.VelocityChange);
	}



	void OnCollisionEnter (Collision col){
		//ブロックにぶつかるとブロックカウント-1
		if (col.gameObject.tag == "Block") {
			//blockCt -= 1;
		} else if (col.gameObject.tag == "Racket") {
			if (Mathf.Abs (ballVelocity.x) < 2.0f) {
				ballVelocity = gameObject.GetComponent<Rigidbody> ().velocity;
				ballVelocity.x += 1.0f;
				ballVelocity.x *= 5.0f;
				GetComponent<Rigidbody> ().velocity = ballVelocity;
			}
			if (Mathf.Abs (ballVelocity.y) < 1.5f) {
				ballVelocity = gameObject.GetComponent<Rigidbody> ().velocity;
				ballVelocity.y += 1.0f;
				ballVelocity.y *= 5.0f;
				GetComponent<Rigidbody> ().velocity = ballVelocity;
			}

		} else if (col.gameObject.tag == "SideWall") {
			//壁に当たったときに上下に対する速度が遅すぎるとき
			if (Mathf.Abs (ballVelocity.y) < 1.0f) {
				ballVelocity = gameObject.GetComponent<Rigidbody> ().velocity;
				ballVelocity.y += 1.0f;
				ballVelocity.y *= 5.0f;
				GetComponent<Rigidbody> ().velocity = ballVelocity;
				Debug.Log (">>>壁に当たった！");
			}
		} else if (col.gameObject.tag == "Treasure") {
			Destroy (gameObject);
		}

	}

}
