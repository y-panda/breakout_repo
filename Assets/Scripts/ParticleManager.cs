﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour {

	ParticleSystem particle;

	// Use this for initialization
	void Start () {
		particle = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		// パーティクルの再生が終了したらGameObjectを削除
		if (particle.isPlaying == false) Destroy(gameObject);
	}
}
