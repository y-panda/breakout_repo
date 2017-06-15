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

	public float baseWidth = 2160f;
	public float baseHeight = 3840f;
	float touchX;
	float touchY;
	Vector3 shootVec;



	void Start(){
		rb = GetComponent<Rigidbody>();
		ballVelocity = gameObject.GetComponent<Rigidbody>().velocity;
		BallShoot ();
	}


	void Update ()	{
		/*touchX = baseWidth *
			(Input.mousePosition.x / Screen.width)-(baseWidth/2);
		touchY = baseHeight *
			(Input.mousePosition.y / Screen.height)-(baseHeight/2);
		Debug.Log("( "+touchX*(3f/1080f)+" , "+touchY*(5f/1920f)+" )");*/
		//Debug.Log("( "+touchX+" , "+touchY+" )");

		Camera orthoCamera = gameObject.GetComponent<Camera> ();

		//Debug.Log("( "+Input.mousePosition.x+" , "+Input.mousePosition.y+" )");

		Vector3 screenPos = Input.mousePosition;
		//Debug.Log (screenPos);
		Vector3 worldPos = orthoCamera.ScreenToWorldPoint(screenPos);
		Debug.Log (worldPos);
		//Vector3 worldPos2 = Camera.main.ViewportToWorldPoint(worldPos);
		//Debug.Log (worldPos2);


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
		/*float dx = touchX - gameObject.transform.position.x;
		float dy = touchY - gameObject.transform.position.y;
		float rad = Mathf.Atan2 (dy, dx);*/
		//Debug.Log (gameObject.transform.position);

		shootVec = new Vector3 (2.1f, -2.1f, 0f);
		//shootVec = new Vector3 (touchX*(3f/1080f), touchY*(5f/1920f), 0f);
		//rb.AddForce((transform.up + transform.right) * speed, ForceMode.VelocityChange);
		//rb.AddForce((transform.up) * (1), ForceMode.VelocityChange);
		//rb.AddForce((shootVec) * (1f), ForceMode.VelocityChange);
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
