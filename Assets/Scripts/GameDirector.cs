﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameDirector : MonoBehaviour {

	bool gamePlayingIs = true;
	float countTime = 100.0f; //制限時間

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
		racket.GetComponent<Racket> ().moveModeIs=false; //バーを固定
		racket.GetComponent<Racket> ().SetPos (); //初期位置に固定

		newBallPos = racket.transform.position;
		newBallPos.y += 0.05f; // ラケットの少し上にボールの座標を設定
		newBallPos.z = 1.2f; 
		Instantiate(ballPref, newBallPos, Quaternion.identity);//ボールを生成
	}
	
	void Update () {
		//スタートしてからの秒数
		if (gamePlayingIs) {
			countTime -= Time.deltaTime; 
			timerText.text = countTime.ToString("F0");	
			if (countTime<=0f) { //時間切れ
				//GameOver ();
			}
		}

	}


	public void GameClear(){
		// クリア時の処理
		bgmSound.Stop ();
		clearSound.PlayOneShot (clearSound.clip);
		gamePlayingIs = false;
		ClearPanel.SetActive (true);
		ClearTreasure.SetActive (true);

		// スコア関係
		CalcScore();
	}

	public void CalcScore(){
		gameResultText.text = "宝石獲得！クリア！";
		string sceneName; //現在のシーン名
		string highScoreKey;

		int score;
		int highScore;

		sceneName = SceneManager.GetActiveScene().name;
		highScoreKey = sceneName + "HighScore"; //現在のシーン名が含まれたkey名作成

		score = (int)countTime * 10 + playerLife * 100;
		highScore = PlayerPrefs.GetInt (highScoreKey);

		if (highScore< score) {
			gameResultText.text += "\nハイスコア!:" + (score).ToString ("F0");
			highScore = score;
			PlayerPrefs.SetInt (highScoreKey, highScore);
		} else {
			gameResultText.text = "\nスコア:" + (score).ToString ("F0");
		}
		gameScoreText.text = "~現在のハイスコア~\n" + (highScore).ToString ("F0");


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
			countTime -= 15;
			playerLife--;
			lifeText.text = "残り"+playerLife.ToString()+"回";
			Destroy (col.gameObject);
			GameStart ();
		}
	}
}
