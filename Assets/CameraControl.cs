using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	public GameObject lookTarget;
	public GameObject anchor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = (anchor.transform.position);
		this.transform.LookAt (lookTarget.transform);
	}
}
