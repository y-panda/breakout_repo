using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClearScript : MonoBehaviour {

	void Start () {

		this.gameObject.GetComponent<Text>().enabled = false;

	}



	public void Win () {
		gameObject.GetComponent<Text>().enabled = true;
	}
}
