using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

	// ボールの運動
	float maxSpeed = 6f;
	Rigidbody rb;
	Vector3 ballVelocity;

	// 発射角度決定に必要なパラメータ
	GameObject orthoObject;
	bool shootIdlingIs = true;
	Vector3 shootVec;
	GameObject lightParent;

	GameObject racket;
	public GameObject burstPrefab;
	public GameObject bombPrefab;

	// サウンド関係
	AudioSource burnSound;
	AudioSource barSound;

	void Start(){
		
		racket = GameObject.Find ("bar");
		orthoObject = GameObject.Find ("GameObject");
		// サーチライトの電気をつける
		lightParent = GameObject.Find ("LightParent");
		lightParent.transform.position = new Vector3(transform.position.x, transform.position.y, 1f);
		lightParent.transform.FindChild ("SearchLight").gameObject.GetComponent<Light> ().spotAngle = 21;

		AudioSource[] audiosouces = gameObject.GetComponents<AudioSource> ();
		burnSound = audiosouces [0];
		barSound = audiosouces[1];

		rb = GetComponent<Rigidbody>();
		ballVelocity = gameObject.GetComponent<Rigidbody>().velocity;
		BallShoot ();
	}


	void Update ()	{
		//タッチしてる間、角度計算する
		if (shootIdlingIs&&Input.GetMouseButton (0)) {
			racket.GetComponent<Racket> ().moveModeIs = false;
			//発射角度を計算
			shootVec = orthoObject.GetComponent<TransformScreenToWorld> ().CalcShootVec (gameObject);
		}

		//指離したら発射
		if (shootIdlingIs&&Input.GetMouseButtonUp (0)&&shootVec.y>0f) {
			shootIdlingIs = false;
			//サーチライトを消す
			lightParent.transform.FindChild ("SearchLight").gameObject.GetComponent<Light> ().spotAngle = 0;

			BallShoot ();
		}
		// 発射後に画面に触ったとき、ラケットが操作可能状態になる
		if (!shootIdlingIs&&Input.GetMouseButton (0)) {
			racket.GetComponent<Racket> ().moveModeIs = true; //ラケットの操作可能にする
		}

		//速度を正規化
		GetComponent<Rigidbody> ().velocity = GetComponent<Rigidbody> ().velocity.normalized * maxSpeed;
	}

	//指定した角度に発射
	void BallShoot(){
		rb.AddForce((shootVec) * (1f), ForceMode.VelocityChange);
	}



	void OnCollisionEnter (Collision col){
		switch (col.gameObject.tag) {
		case "Block":
			burnSound.PlayOneShot (burnSound.clip);
			//砂煙を発生
			Instantiate (burstPrefab, col.gameObject.transform.position, Quaternion.identity);
			break;

		case "Hard2Block":
			burnSound.PlayOneShot (burnSound.clip);
			//砂煙を発生
			Instantiate (burstPrefab, col.gameObject.transform.position, Quaternion.identity);
			break;

		case "Bomb":
			//burnSound.PlayOneShot (burnSound.clip);
			Debug.Log ("爆弾に当たった");
			col.gameObject.GetComponent<Explosion> ().explodedIs = true;
			Instantiate (bombPrefab, col.gameObject.transform.position, Quaternion.identity);

			break;

		case "Racket":
			barSound.PlayOneShot (barSound.clip);
			Debug.Log (ballVelocity);
			if (Mathf.Abs (ballVelocity.x) < 1.0f) {
				ballVelocity = gameObject.GetComponent<Rigidbody> ().velocity;
				if (ballVelocity.x == 0f) {
					ballVelocity.x += 1.0f;
				}
				ballVelocity.x *= 2.5f;
				GetComponent<Rigidbody> ().velocity = ballVelocity;
			}
			if (Mathf.Abs (ballVelocity.y) < 1.5f) {
				ballVelocity = gameObject.GetComponent<Rigidbody> ().velocity;
				ballVelocity.y += 1.0f;
				ballVelocity.y *= 5.0f;
				GetComponent<Rigidbody> ().velocity = ballVelocity;
			}
			break;

		case "SideWall":
			if (Mathf.Abs (ballVelocity.y) < 40.0f) {
				//Debug.Log (">>>速度調整します");
				ballVelocity = gameObject.GetComponent<Rigidbody> ().velocity;
				if (ballVelocity.y == 0f) {
					ballVelocity.y += 1.0f;
				}
				ballVelocity.y *= 5.0f;
				GetComponent<Rigidbody> ().velocity = ballVelocity;
			}
			break;

		case "Treasure":
			Destroy (gameObject);
			break;

		default:
			break;
		}
			

		/*if (col.gameObject.tag == "Block"||col.gameObject.tag == "Hard2Block") {
			burnSound.PlayOneShot(burnSound.clip);
			//砂煙を発生
			Instantiate (burstPrefab, col.gameObject.transform.position, Quaternion.identity);

		} else if (col.gameObject.tag == "Racket") {
			barSound.PlayOneShot (barSound.clip);
			Debug.Log (ballVelocity);
			if (Mathf.Abs (ballVelocity.x) < 1.0f) {
				ballVelocity = gameObject.GetComponent<Rigidbody> ().velocity;
				if (ballVelocity.x == 0f) {
					ballVelocity.x += 1.0f;
				}
				ballVelocity.x *= 2.5f;
				GetComponent<Rigidbody> ().velocity = ballVelocity;
			}
			if (Mathf.Abs (ballVelocity.y) < 1.5f) {
				ballVelocity = gameObject.GetComponent<Rigidbody> ().velocity;
				ballVelocity.y += 1.0f;
				ballVelocity.y *= 5.0f;
				GetComponent<Rigidbody> ().velocity = ballVelocity;
			}

		} else if (col.gameObject.tag == "SideWall") {
			//Debug.Log (">>>壁に当たった！");
			//Debug.Log (ballVelocity);
			//壁に当たったときに上下に対する速度が遅すぎるとき
			if (Mathf.Abs (ballVelocity.y) < 40.0f) {
				//Debug.Log (">>>速度調整します");
				ballVelocity = gameObject.GetComponent<Rigidbody> ().velocity;
				if (ballVelocity.y == 0f) {
					ballVelocity.y += 1.0f;
				}

				ballVelocity.y *= 5.0f;
				GetComponent<Rigidbody> ().velocity = ballVelocity;
				//Debug.Log (">>>"+ballVelocity);
			}
		} else if (col.gameObject.tag == "Treasure") {
			Destroy (gameObject);
		}*/

	}

}
