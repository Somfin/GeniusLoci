﻿using UnityEngine;
using System.Collections;

public class BulletKill : MonoBehaviour {
	public GameObject particles;
	public GameObject bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void die(){
		Destroy (gameObject, 1.0f);
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		GetComponent<Light> ().enabled = false;

		GetComponent<BulletCollide> ().enabled = false;
		GetComponent<BulletCable> ().kill ();
		GetComponent<AudioSource> ().Stop ();

		Destroy (bullet);
		particles.GetComponent<ParticleSystem>().Stop();
	}
}
