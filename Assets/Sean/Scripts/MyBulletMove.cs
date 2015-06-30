//This is primarily Woody's code, but I changed a few lines
using UnityEngine;
using System.Collections;

public class MyBulletMove: MonoBehaviour {

	public float movementSpeed;
	public float lifeSpan;
	
	private Rigidbody body;
	private Vector3 move;
	private float life;
	
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate () {
		life += Time.deltaTime;
		if (life > lifeSpan) {
			GetComponent<MyBulletKill>().die();
		}
	}
}
