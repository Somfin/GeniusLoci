using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {
	public float moveRate;
	public float jumpRate;
	public float maxJumpTime;

	private Vector3 stick;
	private Vector3 move;
	private float stickX;
	private float stickY;
	private float jump;
	public bool jumpAttempt;
	public bool jumpHold;
	public bool jumping;
	private float jumpTime;

	// Use this for initialization
	void Start () {
		stickX = 0f;
		stickY = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		stickX = Input.GetAxisRaw ("Horizontal");
		stickY = Input.GetAxisRaw ("Vertical");
		jumpAttempt = Input.GetAxisRaw ("Jump") == 1;
	}

	void FixedUpdate (){
		stick.Set (stickX, 0f, stickY);
		stick = stick.normalized;
		Move (stick.x, stick.z);
	}

	void Move (float h, float v){
		move.Set (h, 0f, v);
		move = move.normalized * moveRate * Time.deltaTime;
		if (jumpAttempt && !jumping) {
			jumping = true;
			jumpHold = true;
		}
		if (!jumpAttempt) {
			jumpHold = false;
			jumpTime = 0;
		}
		if (jumpHold && jumpTime < maxJumpTime) {
			jumpTime += Time.deltaTime;
			move.Set (move.x, jumpRate * Time.deltaTime, move.z);
		}
		transform.Translate (move);
	}

	void OnCollisionEnter(Collision collision){
		if (collision.collider.tag == "World") {
			jumping = false;
			jumpTime = 0;
		}
	}
}
