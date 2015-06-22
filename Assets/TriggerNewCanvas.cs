using UnityEngine;
using System.Collections;

public class TriggerNewCanvas : TriggerBase {
	public GameObject newCanvas;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public override void Activate() {
		newCanvas.SetActive (true);
		gameObject.SetActive (false);
	}
}
