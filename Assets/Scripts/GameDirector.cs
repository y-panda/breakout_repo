using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour {

	bool gamePlayingIs = true;
	float countTime = 180.0f;

	public Text timerText;
	public Text lifeText;
	public Text gameResultText;
	public Text gameScoreText;

	[System.NonSerialized]
	public int playerLife=5;

	public GameObject ballPref;
	public GameObject racket;
	Vector3 newBallPos;
	//ライトはz=-1.7

	void Start () {
		GameStart ();
	}

	//ゲーム開始
	void GameStart(){
		racket.GetComponent<Racket> ().SetSliderValue (); //スライダーの位置を固定

		newBallPos = racket.transform.position;
		newBallPos.y += 0.5f; // ラケットの少し上にボールの座標を設定
		Instantiate(ballPref, newBallPos, Quaternion.identity);//ボールを生成
	}
	
	void Update () {
		//スタートしてからの秒数
		if (gamePlayingIs) {
			countTime -= Time.deltaTime; 
			timerText.text = countTime.ToString("F1");	
		}

	}


	public void GameClear(){
		gamePlayingIs = false;
		gameResultText.text = "財宝獲得！クリア！";
		gameScoreText.text = "スコア:" + (countTime * 10f).ToString ("F0");
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
