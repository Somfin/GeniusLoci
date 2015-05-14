using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	public GameObject lookTarget;
	public GameObject anchor;
	public GameObject player;
	public float snappiness;

	private Vector3 target;
	private Vector3 pos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		target = Vector3.Lerp (target, lookTarget.transform.position, snappiness);
		pos = anchor.transform.position;
		float dist = Vector3.Distance (pos, player.transform.position);
		RaycastHit found;

		if (Physics.Raycast (player.transform.position, (pos - player.transform.position), out found, dist)) {
			if (found.collider.tag != "Trigger"){
				Debug.DrawLine (player.transform.position, pos, Color.red);
				pos = new Vector3 (found.point.x, pos.y, found.point.z);
			}
		} else {
			Debug.DrawLine (player.transform.position, pos, Color.white);
		}

		this.transform.position -= (transform.position - pos) * snappiness;
		this.transform.LookAt (target);
		Debug.DrawLine (this.transform.position, target);
		Debug.DrawRay (lookTarget.transform.position, Vector3.up);
		Debug.DrawRay (target, Vector3.forward);
	}
}
