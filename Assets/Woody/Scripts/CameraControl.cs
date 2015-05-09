using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	public GameObject lookTarget;
	public GameObject anchor;
	public float snappiness;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.position -= (transform.position - anchor.transform.position) * snappiness;
		this.transform.LookAt (lookTarget.transform);
	}
}
