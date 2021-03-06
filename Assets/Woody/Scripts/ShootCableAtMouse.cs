﻿using UnityEngine;
using System.Collections;

public class ShootCableAtMouse : MonoBehaviour {
	public GameObject bullet;
	public GameObject backBlast;
	public float shotSpeed;
	public float shotDelay;
	public float shotCooldown;
	public Animator anim;
	public float currentDelay;
	
	private float currentCooldown;
	private bool trigger;
	private bool firing;
	private bool fired;
	public GameObject currentBullet;

	// Use this for initialization
	void Start () {
		firing = false;
		fired = false;
		currentBullet = null;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw ("Fire1") == 1) {
			trigger = true;
		} 
		if (trigger && currentCooldown == 0) {
			anim.SetBool ("IsShooting", true);
			currentDelay += Time.deltaTime;
			if (currentDelay > shotDelay){
				trigger = false;
				firing = true;
				currentDelay = 0;
			}
		}
		if (fired) {
			anim.SetBool ("IsShooting", false);
			currentCooldown += Time.deltaTime;
			if (currentCooldown > shotCooldown){
				fired = false;
				currentCooldown = 0;
			}
		}
	}

	void FixedUpdate () {
		if (firing && !fired) {
			if (currentBullet != null){
				currentBullet.GetComponent<BulletKill>().die();
			}
			firing = false;
			fired = true;
			GameObject blast = GameObject.Instantiate (backBlast, transform.position + transform.forward + new Vector3 (0f, 0.6f), transform.rotation) as GameObject;
			Destroy (blast, 2.0f);

			GameObject newBullet = GameObject.Instantiate (bullet, transform.position + transform.forward + new Vector3 (0f, 0.6f), transform.rotation) as GameObject;
			currentBullet = newBullet;
			foreach (Collider c in GetComponents<Collider>()){
				Physics.IgnoreCollision (c, currentBullet.GetComponent<Collider>());
			}

			currentBullet.GetComponent<BulletCollide>().setCreator(gameObject);
			GetComponent<LineRenderer>().enabled = true;
			currentBullet.GetComponent<BulletCable>().setCable(GetComponent<LineRenderer>());

			currentBullet.GetComponent<Rigidbody>().AddForce (this.transform.forward * shotSpeed);
			currentBullet.name = "Active Spark";
		}
	}
}
