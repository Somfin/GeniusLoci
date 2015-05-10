using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	public GameObject lookTarget;
	public GameObject anchor;
	public GameObject player;
	public float snappiness;

	private Vector3 target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		target = Vector3.Lerp (target, lookTarget.transform.position, snappiness);
		this.transform.position -= (transform.position - anchor.transform.position) * snappiness;
		this.transform.LookAt (target);
		Debug.DrawLine (this.transform.position, target);
		Debug.DrawLine (this.transform.position, player.transform.position);
		Debug.DrawRay (lookTarget.transform.position, Vector3.up);
		Debug.DrawRay (target, Vector3.forward);
	}
}
