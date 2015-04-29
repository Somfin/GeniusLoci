using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {
	public float MovementSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		transform.Translate (Vector3.forward * MovementSpeed);
	}
}
