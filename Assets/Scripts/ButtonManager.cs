using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {


	public void OnStage0Load(){
		SceneManager.LoadScene("stage0");
	}

	public void OnStage1Load(){
		SceneManager.LoadScene("stage1");
	}
}
