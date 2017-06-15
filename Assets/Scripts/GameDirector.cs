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

	public float baseWidth = 2160f;
	public float baseHeight = 3840f;

	// Use this for initialization
	void Start () {
		GameStart ();
	}

	void GameStart(){
		newBallPos = racket.transform.position;
		newBallPos.y += 0.5f;
		//ボールを生成
		Instantiate(ballPref, newBallPos, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		float touchX = baseWidth *
		               (Input.mousePosition.x / Screen.width);
		float touchy = baseHeight *
			(Input.mousePosition.y / Screen.height);
		Debug.Log("( "+touchX+" , "+touchy+" )");


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
