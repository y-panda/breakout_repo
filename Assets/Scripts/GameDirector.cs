using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour {

	float countTime = 0.0f;
	public Text timerText;
	public Text lifeText;

	[System.NonSerialized]
	public int playerLife=5;

	public GameObject ballPref;
	public GameObject racket;
	Vector3 newBallPos;



	// Use this for initialization
	void Start () {
		GameStart ();
	}

	//ゲーム開始
	void GameStart(){
		newBallPos = racket.transform.position;
		newBallPos.y += 0.5f; // ラケットの少し上にボールの座標を設定
		Instantiate(ballPref, newBallPos, Quaternion.identity);//ボールを生成
	}
	
	// Update is called once per frame
	void Update () {
		//スタートしてからの秒数
		countTime += Time.deltaTime; 
		timerText.text = countTime.ToString("F1");
	}
		

	// ボールが1番下の床に当たったときの処理
	void OnCollisionEnter (Collision col){

		if (col.gameObject.tag == "Ball") {
			Debug.Log ("playerLife:"+playerLife);
			playerLife--;
			lifeText.text = playerLife.ToString();
			//SceneManager.LoadScene("stage1");
			Destroy (col.gameObject);
			GameStart ();
		}
	}
}
