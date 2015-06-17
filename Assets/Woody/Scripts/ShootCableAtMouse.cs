﻿using UnityEngine;
using System.Collections;

public class ShootCableAtMouse : MonoBehaviour {
	public GameObject bullet;
	public LineRenderer cable;
	public GameObject backBlast;
	public float shotSpeed;
	public float shotDelay;
	public float shotCooldown;
	
	private float currentCooldown;
	private float currentDelay;
	private bool trigger;
	private bool firing;
	private bool fired;
	private bool bulletLive;
	private GameObject currentBullet;

	// Use this for initialization
	void Start () {
		firing = false;
		fired = false;
		currentBullet = null;
		cable.useWorldSpace = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw ("Fire1") == 1) {
			trigger = true;
		} 
		if (trigger && currentCooldown == 0) {
			currentDelay += Time.deltaTime;
			if (currentDelay > shotDelay){
				trigger = false;
				firing = true;
				currentDelay = 0;
			}
		}
		if (fired) {
			currentCooldown += Time.deltaTime;
			if (currentCooldown > shotCooldown){
				fired = false;
				currentCooldown = 0;
			}
		}
		if (currentBullet != null && bulletLive) {
			cable.enabled = true;
			cable.SetPosition (0, this.transform.position);
			cable.SetPosition (1, currentBullet.transform.position);
		} else {
			cable.enabled = false;
		}
	}

	void FixedUpdate () {
		if (firing && !fired && currentBullet != null) {
			currentBullet.GetComponent<BulletKill>().die ();
			bulletLive = false;
			currentBullet = null;
		}
		if (firing && !fired) {
			firing = false;
			fired = true;
			bulletLive = true;
			GameObject blast = GameObject.Instantiate (backBlast, transform.position, transform.rotation) as GameObject;
			Destroy (blast, 2.0f);

			GameObject newBullet = GameObject.Instantiate (bullet, transform.position, transform.rotation) as GameObject;
			currentBullet = newBullet;
			foreach (Collider c in GetComponents<Collider>()){
				Physics.IgnoreCollision (c, currentBullet.GetComponent<Collider>());
			}

			currentBullet.GetComponent<BulletCollide>().setCreator(gameObject);

			currentBullet.GetComponent<Rigidbody>().AddForce (this.transform.forward * shotSpeed);
			currentBullet.name = "Active Spark";
		}
	}

	public void bulletHit(){
		bulletLive = false;
	}

	void OnGUI() {
		if (fired) {
			GUI.Label (new Rect (0, 0, Screen.width, Screen.height), "...");
		} else if (firing) {
			GUI.Label (new Rect (0, 0, Screen.width, Screen.height), "BANG!");
		} else if (trigger) {
			GUI.Label (new Rect (0, 0, Screen.width, Screen.height), "Wait for it...");
		} else {
			GUI.Label (new Rect (0, 0, Screen.width, Screen.height), "Ready to fire.");
		}
	}
}
