using UnityEngine;
using System.Collections;

public class JumpReset : MonoBehaviour {
	public PlayerMover mover;
	public string contact;
	public string stay;
	public Animator anim;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collide){
		contact = collide.name;
		if (collide.tag == "World") {
			mover.resetJump();
		}
	}

	void OnTriggerStay(Collider collide){
		anim.SetBool ("Grounded", true);
		stay = collide.name;
		if (collide.tag == "World") {
			mover.resetJump();
		}
	}

	void OnTriggerExit(Collider collide){
		anim.SetBool ("Grounded", false);
	}
}
