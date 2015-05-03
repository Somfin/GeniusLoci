using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {
	public float movementSpeed;
	public float rangeLimit;

	private Vector3 move;
	private float distance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		move = Vector3.forward * movementSpeed;
		transform.Translate (move);
		distance += move.magnitude;
		if (distance > rangeLimit) {
			GetComponent<BulletKill>().die();
		}
	}
}
