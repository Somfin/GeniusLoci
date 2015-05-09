using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {
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
			GetComponent<BulletKill>().die();
		}
	}
}
