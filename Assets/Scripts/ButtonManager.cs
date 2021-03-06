﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public void OnTitleLoad(){
		SceneManager.LoadScene("title");
	}

	public void OnHowToPlayLoad(){
		SceneManager.LoadScene("HowToPlay");
	}


	public void OnStageLoad(string stageNo){
		//タイトル画面から呼び出されたときの処理
		if (stageNo=="0") {
			string scoreKey;
			//各ステージのスコアを初期化
			for (int i = 0; i < 5; i++) {
				scoreKey = "stage" + i.ToString() + "Score";
				PlayerPrefs.SetString (scoreKey, "獲得なし");
			}
			// HPを設定
			PlayerPrefs.SetInt ("PlayerHP", 5);
		}
		SceneManager.LoadScene("stage"+stageNo);
	}

	public void OnGameOverLoad(){
		SceneManager.LoadScene("GameOver");
	}
}
