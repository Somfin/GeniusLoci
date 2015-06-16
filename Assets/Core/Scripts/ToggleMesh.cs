using UnityEngine;
using System.Collections;

public class ToggleMesh : TriggerBase
{
	public bool startHidden = true;
	
	void Start ()
	{
		if (startHidden) {
			GetComponent<Renderer> ().enabled = false;
		}
	}
	
	// Can be triggered directly if needed by another trigger.
	public override void Activate(){
		GetComponent<Renderer> ().enabled = !GetComponent<Renderer> ().enabled;
		TriggerChildren ();
	}
}
