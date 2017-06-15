using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottomController : MonoBehaviour {

	public GameObject gameOver;
	bool goTitle = false;

	void Start () {
		
	}
	
	void Update () {
		/*if (goTitle) {
			//GameOverの文字が表示された状態で画面をクリック
			if(Input.GetMouseButtonDown (0)){
				//Application.LoadLevel ("title");//タイトル画面へ遷移
				SceneManager.LoadScene("title");
			}

		}*/
	}
	　　
	void OnCollisionEnter(Collision col){
		//Destroy (col.gameObject);
		//GameOverの文字表示
		//gameOver.SendMessage("Lose");
		//goTitle = true;//update文の実行
	}
}
