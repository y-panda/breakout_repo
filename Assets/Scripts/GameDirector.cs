using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameDirector : MonoBehaviour {

	bool gamePlayingIs = true;
	float countTime = 180.0f; //制限時間

	public Text timerText;
	public Text lifeText;
	public Text gameResultText;
	public Text gameScoreText;
	public GameObject ClearPanel;
	public GameObject ClearTreasure;


	[System.NonSerialized]
	public int playerLife=5;

	public GameObject ballPref;
	public GameObject racket;
	Vector3 newBallPos;
	//ライトはz=-1.7

	AudioSource clearSound;
	AudioSource bgmSound;


	void Start () {
		AudioSource[] audioSources = gameObject.GetComponents<AudioSource> ();
		clearSound = audioSources[0];
		bgmSound = audioSources [1];
		ClearPanel.SetActive (false);
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

			if (countTime<=0f) { //時間切れ
				GameOver ();
			}
		}

	}


	public void GameClear(){
		bgmSound.Stop ();
		clearSound.PlayOneShot (clearSound.clip);
		gamePlayingIs = false;
		ClearPanel.SetActive (true);
		ClearTreasure.SetActive (true);
		gameResultText.text = "宝石獲得！クリア！";
		gameScoreText.text = "スコア:" + (countTime * 10f).ToString ("F0");
	}

	public void GameOver(){
		gamePlayingIs = false;
		racket.GetComponent<Racket> ().moveModeIs=false; //バーを固定
		gameResultText.text = "ゲームオーバー…";
	}


	public void GoNextStage(){
		SceneManager.LoadScene("stage1");
	}

	// ボールが1番下の床に当たったときの処理
	void OnCollisionEnter (Collision col){
		if (col.gameObject.tag == "Ball") {
			//Debug.Log ("playerLife:"+playerLife);
			playerLife--;
			lifeText.text = playerLife.ToString();
			//SceneManager.LoadScene("stage1");
			Destroy (col.gameObject);
			GameStart ();
		}
	}
}
