using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {
	public float moveRate;
	public float jumpRate;
	public float jumpDecay;
	public float currentJump;
	public Animator anim;
	public float stepFinder;
	public AudioClip[] clips;

	private AudioSource sound ;
	private Vector3 stick;
	private Vector3 move;
	private float stickX;
	private float stickY;
	private float jump;
	public bool jumped;			// Whether or not I have started jumping
	public bool jumping;		// Whether or not I am currently jumping
	public bool jumpHold;		// Whether or not I am currently holding down the jump button
	private float jumpTime;
	private Rigidbody body;

	// Use this for initialization
	void Start () {
		stickX = 0f;
		stickY = 0f;
		body = GetComponent<Rigidbody> ();
		sound = this.GetComponent<AudioSource> ();
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
		if (anim.GetBool ("Grounded") && !anim.GetBool ("IsShooting")) {
			if (stick.magnitude > 0f) {
				stepFinder += Time.deltaTime;
				if (stepFinder > 0.416666666666f) {
					stepFinder = 0;
					Footstep ();
				}
			} else {
				stepFinder = 0;
			}
		} else {
			stepFinder = 0;
		}
		anim.SetFloat ("Run_Vert", stickY);
		anim.SetFloat ("Run_Horiz", stickX);
		Move (stick.x, stick.z);
	}

	void Move (float h, float v){
		move.Set (h, 0f, v);
		move = move.normalized * moveRate * Time.deltaTime;
		body.useGravity = true;
		anim.SetBool ("IsJumping", false);
		if (jumpHold && !jumping && !jumped) {
			jumping = true;
		}
		if (!jumpHold) {
			body.useGravity = true;
			jumped = false;
			jumpTime = 0;
		}
		if (jumpHold && currentJump > 1) {
			anim.SetBool ("IsJumping", true);
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

	void Footstep(){
		AudioClip clip = clips[Mathf.FloorToInt (Random.Range (0, clips.Length))];
		sound.clip = clip;
		sound.pitch = 1 + Random.Range (-0.1f, 0.1f);
		sound.Play();
	}
}
