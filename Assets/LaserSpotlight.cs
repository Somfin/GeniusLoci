using UnityEngine;
using System.Collections;

public class LaserSpotlight : MonoBehaviour {

	private GameObject player;
	private PlayerMover playerMover;
	private Light spotlight;
	
	// Use this for initialization
	void Start () {

		spotlight = GetComponent<Light> ();
		spotlight.enabled = false;

		player = GameObject.FindGameObjectWithTag ("Player");
		playerMover = player.GetComponent<PlayerMover> ();


	}
	
	// Update is called once per frame
	void Update () {
	
		if (playerMover.jumping && (playerMover.currentJump < playerMover.jumpRate))
			spotlight.enabled = true;
		else
			spotlight.enabled = false;

	}
}
