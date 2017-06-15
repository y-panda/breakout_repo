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


	// Use this for initialization
	void Start () {
		playerLife = 3;
		//ボールを生成
		Instantiate(ballPref, ballPref.transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		countTime += Time.deltaTime; //スタートしてからの秒数
		timerText.text = countTime.ToString("F1");
	}

	public void LossLife(){
		playerLife--;
		Debug.Log ("playerLife:"+playerLife);
		//lifeText.text = playerLife.ToString ();
		//lifeText.text = "";
	}
}
