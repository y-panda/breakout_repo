using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Racket : MonoBehaviour {

	private Vector3 pos;

	public Slider slider;
	float sliderValue = 0f;

	public bool moveModeIs;

	// Use this for initialization
	void Start () {
		moveModeIs = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (!moveModeIs) {
			slider.value = sliderValue;
		}
		pos = gameObject.transform.position;
		pos.x = slider.value;
		gameObject.transform.position = pos;
		/*gameObject.transform.position =
			new Vector3(slider.value, gameObject.transform.position.y, gameObject.transform.position.z);
		*/

	}

	//スライダーの固定位置を決定する
	public void SetSliderValue(){
		sliderValue = slider.value;
	}
}
