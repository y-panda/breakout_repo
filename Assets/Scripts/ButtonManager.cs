using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {


	public void OnStageLoad(string stageNo){
		SceneManager.LoadScene("stage"+stageNo);
	}

	/*public void OnStage0Load(){
		SceneManager.LoadScene("stage0");
	}

	public void OnStage1Load(){
		SceneManager.LoadScene("stage1");
	}

	public void OnStage2Load(string stageNo){
		SceneManager.LoadScene("stage2");
	}*/
}
