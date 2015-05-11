using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 10.0f;
	public float max_speed = 80.0f;

	public float rotation_dampening = 0.05f;

	public Animator playerAnim;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		// Handle movement
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		float mag = GetComponent<Rigidbody> ().velocity.magnitude;

		if (mag < max_speed) {

			if (moveVertical > 0) {
				Vector3 movement = transform.forward * speed;
				GetComponent<Rigidbody> ().AddForce (movement);
				if(!playerAnim.GetBool("WalkForward")){
					playerAnim.CrossFade("Walk", 0.1f);
					playerAnim.SetBool("WalkBackward", false);
					playerAnim.SetBool("WalkForward", true);
				}
			} else if (moveVertical < 0) {
				Vector3 movement = transform.forward * speed * -1;
				GetComponent<Rigidbody> ().AddForce (movement);
				if(!playerAnim.GetBool("WalkBackward")){
					playerAnim.CrossFade("Walk 0", 0.1f);
					playerAnim.SetBool("WalkBackward", true);
					playerAnim.SetBool("WalkForward", false);
				}
			} else{

				if(playerAnim.GetBool("WalkBackward") || playerAnim.GetBool("WalkForward")){
					playerAnim.SetBool("WalkForward", false);
					playerAnim.SetBool("WalkBackward", false);
					playerAnim.CrossFade("Idle", 0.1f);
				}

			}
		}



		// Handle camera rotation
		float mouseX = Input.GetAxis ("Mouse X");
		transform.Rotate (0, mouseX * rotation_dampening, 0);
		transform.Rotate (0, moveHorizontal * rotation_dampening, 0);
	}
}
