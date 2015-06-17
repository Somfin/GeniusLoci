using UnityEngine;
using System.Collections;

public class PlayerPuller : MonoBehaviour
{
	private Rigidbody body;
	public bool pulling;
	public LineRenderer cable;
	private GameObject target;

	// Use this for initialization
	void Start ()
	{
		this.body = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void FixedUpdate (){
		if (pulling) {
			if (GetComponent<PlayerMover> ().isActiveAndEnabled){
				GetComponent<Rigidbody> ().useGravity = false;
				GetComponent<PlayerMover> ().enabled = false;
				GetComponent<ShootCableAtMouse> ().bulletHit ();
				GetComponent<ShootCableAtMouse> ().enabled = false;
				GetComponent<RotateToMouse> ().enabled = false;
			}
			cable.enabled = true;
			cable.SetPosition (0, transform.position);
			cable.SetPosition (1, target.transform.position);
			body.MovePosition (Vector3.MoveTowards (transform.position, target.transform.position, 1));
			if (Vector3.Distance (transform.position, target.transform.position) < 3){
				pulling = false;
				this.target = null;
				GetComponent<Rigidbody> ().useGravity = true;
				GetComponent<PlayerMover> ().enabled = true;
				GetComponent<PlayerMover> ().currentJump = 0;
				GetComponent<ShootCableAtMouse> ().enabled = true;
				GetComponent<RotateToMouse> ().enabled = true;
				cable.enabled = false;
			}
		}
	}

	public void pullTo (GameObject targ){
		pulling = true;
		this.target = targ;
	}

	void OnCollisionEnter (Collision collision){
		if (collision.collider.tag == "Pull") {
			pulling = false;
			this.target = null;
			GetComponent<Rigidbody> ().useGravity = true;
			GetComponent<PlayerMover> ().enabled = true;
			GetComponent<ShootCableAtMouse> ().enabled = true;
			GetComponent<RotateToMouse> ().enabled = true;
		}
	}
}

