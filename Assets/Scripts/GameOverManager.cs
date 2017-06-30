using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

	public Text gameScoresText;
	string scoreKey;
	string scores;

	void Start () {
		//各ステージのスコアを読み込む
		for (int i = 0; i < 5; i++) {
			scoreKey = "stage" + i.ToString() + "Score";
			scores += "stage" + i.ToString()+":"+PlayerPrefs.GetString (scoreKey)+"\n";
		}
		gameScoresText.text = scores;
	}

}
