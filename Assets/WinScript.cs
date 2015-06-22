using UnityEngine;
using System.Collections;

public class WinScript : MonoBehaviour {
	public float move;
	public Animator anim;
	public GameObject cameraAnchor;

	private bool win;
	private float moved;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (win && moved < move) {
			Vector3 mover = transform.forward * Time.deltaTime;
			transform.Translate (mover);
			moved += mover.magnitude;
		}
	}

	public void Win (GameObject heart){
		cameraAnchor.transform.position = new Vector3(cameraAnchor.transform.position.x, 0f, cameraAnchor.transform.position.z);
		transform.LookAt (heart.transform);
		GetComponent<PlayerMover> ().enabled = false;
		GetComponent<RotateToMouse> ().enabled = false;
		GetComponent<ShootCableAtMouse> ().enabled = false;
		win = true;
		anim.SetBool ("Win", true);
	}
}
