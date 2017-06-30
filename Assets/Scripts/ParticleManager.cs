using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour {

	ParticleSystem particle;
	void Start () {
		particle = GetComponent<ParticleSystem>();
	}

	void Update () {
		// パーティクルの再生が終了したらGameObjectを削除
		if (particle.isPlaying == false) Destroy(gameObject);
	}
}
