using UnityEngine;
using System.Collections;

public class JumpReset : MonoBehaviour {
	public PlayerMover mover;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collide){
		if (collide.tag == "World") {
			mover.resetJump();
		}
	}
}
