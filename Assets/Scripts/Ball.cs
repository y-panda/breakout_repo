using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {
	
	public GameObject gameClear;
	int speed = 3;
	public int blockCt = 20;
	Rigidbody rb;
	Vector3 v;

	void Start(){
		rb = GetComponent<Rigidbody>();
		rb.AddForce((transform.up + transform.right) * speed, ForceMode.VelocityChange);
		//rb.AddForce((transform.up) * (-5), ForceMode.VelocityChange);
	}


	void Update ()	{
		Debug.Log (gameObject.GetComponent<Rigidbody>().velocity);
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



	void OnCollisionEnter (Collision col){
		//ブロックにぶつかるとブロックカウント-1
		if (col.gameObject.tag == "Block") {
			blockCt -= 1;
		}else if(col.gameObject.tag == "Racket"){
			
			//ラケットに当たったときに、まっすぐだったら少し横に力をかけてあげる
			//（上下運動ループを避けるため）
			if (gameObject.GetComponent<Rigidbody> ().velocity.x <= 5.0f
				&&gameObject.transform.position.x<=0f) {
				rb.AddForce((transform.right) * (1f), ForceMode.VelocityChange);
			}else if(gameObject.GetComponent<Rigidbody> ().velocity.x <= 5.0f
				&&gameObject.transform.position.x>0f) {
				rb.AddForce((transform.right) * (-1f), ForceMode.VelocityChange);
			}

			if (gameObject.GetComponent<Rigidbody> ().velocity.y <= 1.5f) {
				rb.AddForce((transform.up) * (1f), ForceMode.VelocityChange);
			}

		}
			
	}
}
