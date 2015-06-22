using UnityEngine;
using System.Collections;

public class TriggerWin : TriggerBase {
	public GameObject heart;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Activate() {
		GameObject.FindGameObjectWithTag ("Player").GetComponent<WinScript> ().Win (heart);
	}
}
