using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour {

	float countTime = 0.0f;
	public Text timerText;
	public Text lifeText;

	public int playerLife = 3;

	public GameObject ballPref;


	// Use this for initialization
	void Start () {
		//ボールを生成
		Instantiate(ballPref, ballPref.transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		countTime += Time.deltaTime; //スタートしてからの秒数
		timerText.text = countTime.ToString("F1");
	}

	public void LossLife(){
		playerLife -= 1;
		lifeText.text = playerLife.ToString ("F0");
	}
}
