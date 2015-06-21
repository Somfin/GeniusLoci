using UnityEngine;
using System.Collections;

public class JumpReset : MonoBehaviour {
	public PlayerMover mover;
	public string contact;
	public string stay;
	public AudioSource sound;
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
			if (!anim.GetBool ("Grounded")){
				anim.SetBool ("Grounded", true);
				sound.pitch = 1 + (Random.Range (-0.1f, 0.1f));
				sound.Play();
			}
			mover.resetJump();
		}
	}

	void OnTriggerStay(Collider collide){
		stay = collide.name;
		if (collide.tag == "World") {
			anim.SetBool ("Grounded", true);
			mover.resetJump();
		}
	}

	void OnTriggerExit(Collider collide){
		anim.SetBool ("Grounded", false);
	}
}
