using UnityEngine;
using System.Collections;

public class WinScript : MonoBehaviour {
	public float move;
	public float speed;
	public Animator anim;
	public GameObject cameraAnchor;

	private bool win;
	private float moved;
	public Vector3 winVector;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (win && moved < move) {
			transform.Translate (new Vector3(0f, 0f, Time.deltaTime) * speed);
			moved += Time.deltaTime;
		}
	}

	public void Win (GameObject heart){
		winVector = heart.transform.position - transform.position;
		winVector.y = 0;
		transform.rotation = Quaternion.LookRotation (winVector);


		GetComponent<PlayerMover> ().enabled = false;
		GetComponent<Crosshair> ().enabled = false;
		GetComponent<RotateToMouse> ().enabled = false;
		GetComponent<ShootCableAtMouse> ().enabled = false;
		Destroy(GameObject.FindGameObjectWithTag ("Crosshair"));
		win = true;
		anim.SetBool ("Win", true);
	}
}
