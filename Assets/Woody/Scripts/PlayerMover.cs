using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {
	public float moveRate;
	public float turnRate;

	private Vector3 stick;
	private Vector3 move;
	private Vector3 rotate;
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
		stick.Set (stickX * 2, stickY, 0);
		stick = stick.normalized;
		Turn (stick.x);
		Move (stick.y);
	}

	void Move (float v){
		move.Set (0f, 0f, v);
		move = move.normalized * moveRate * Time.deltaTime;
		transform.Translate (move);
	}

	void Turn (float h){
		rotate.Set (0f, h, 0f);
		rotate = rotate.normalized * turnRate * Time.deltaTime;
		transform.Rotate (rotate);
	}
}
