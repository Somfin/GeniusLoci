using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {
	public float moveRate;
	public float jumpRate;
	public float jumpDecay;
	public Animator anim;

	private Vector3 stick;
	private Vector3 move;
	private float stickX;
	private float stickY;
	private float jump;
	public bool jumped;			// Whether or not I have started jumping
	public bool jumping;		// Whether or not I am currently jumping
	public bool jumpHold;		// Whether or not I am currently holding down the jump button
	private float jumpTime;
	public float currentJump;
	private Rigidbody body;

	// Use this for initialization
	void Start () {
		stickX = 0f;
		stickY = 0f;
		body = GetComponent<Rigidbody> ();
		currentJump = jumpRate;
	}
	
	// Update is called once per frame
	void Update () {
		stickX = Input.GetAxisRaw ("Horizontal");
		stickY = Input.GetAxisRaw ("Vertical");
		jumpHold = Input.GetAxisRaw ("Jump") == 1;
	}

	void FixedUpdate (){
		stick.Set (stickX, 0f, stickY);
		stick = stick.normalized;
		if (stick.magnitude > 0.2f) {
			anim.SetBool ("IsRunning", true);
		} else {
			anim.SetBool ("IsRunning", false);
		}
		Move (stick.x, stick.z);
	}

	void Move (float h, float v){
		move.Set (h, 0f, v);
		move = move.normalized * moveRate * Time.deltaTime;
		body.useGravity = true;
		if (jumpHold && !jumping && !jumped) {
			jumping = true;
		}
		if (!jumpHold) {
			body.useGravity = true;
			jumped = false;
			jumpTime = 0;
		}
		if (jumpHold && currentJump > 1) {
			jumped = true;
			body.useGravity = false;
			jumpTime += Time.deltaTime;
			move.Set (move.x, currentJump * Time.deltaTime, move.z);
			currentJump -= (currentJump * jumpDecay * Time.deltaTime);
		}
		transform.Translate (move);
	}

	public void resetJump(){
		jumping = false;
		if (!jumpHold) {
			jumpTime = 0;
			currentJump = jumpRate;
		}
	}

	void OnCollisionExit(Collision collision){
		if (collision.collider.tag == "World") {
			jumping = true;
		}
	}
}
