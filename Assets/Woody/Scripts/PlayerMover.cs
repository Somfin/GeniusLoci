using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {
	public float moveRate;

	private Vector3 stick;
	private Vector3 move;
	private float stickX;
	private float stickY;

	// Use this for initialization
	void Start () {
		stickX = 0f;
		stickY = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		stickX = Input.GetAxisRaw ("Horizontal");
		stickY = Input.GetAxisRaw ("Vertical");
	}

	void FixedUpdate (){
		stick.Set (stickX, 0f, stickY);
		stick = stick.normalized;
		Move (stick.x, stick.z);
	}

	void Move (float h, float v){
		move.Set (h, 0f, v);
		move = move.normalized * moveRate * Time.deltaTime;
		transform.Translate (move);
	}
}
