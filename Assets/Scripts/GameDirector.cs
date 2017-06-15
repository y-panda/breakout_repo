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
		//GameStart ();
	}

	//ゲーム開始
	void GameStart(){
		newBallPos = racket.transform.position;
		newBallPos.y += 0.5f;
		//ボールを生成
		Instantiate(ballPref, newBallPos, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		


		countTime += Time.deltaTime; //スタートしてからの秒数
		timerText.text = countTime.ToString("F1");
	}

	public void LossLife(){
		//playerLife--;
		Debug.Log ("playerLife:"+playerLife);

		//lifeText.text = playerLife.ToString();
		lifeText.text = "aaaa";

	}


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
