using UnityEngine;
using System.Collections;

public class TriggerShake : TriggerBase {
	public float shake;
	private CameraShake camScript;

	// Use this for initialization
	void Start () {
		camScript = Camera.main.GetComponent<CameraShake> ();
	}
	
	// Update is called once per frame
	public override void Activate () {
		camScript.shakeAmount += shake;
		TriggerChildren ();
	}
}
