using UnityEngine;
using System.Collections;

public class DelayTrigger : TriggerBase {

	public bool triggerOnce = true;
	public bool resetOnTrigger = false;
	public float delay = 0;

	private bool triggered = false;
	private bool counting = false;
	private float startTime;

	public override void Activate(){
		if(!counting || resetOnTrigger){
			startTime = Time.time;
			counting = true;
		}
	}
	
	void Update ()
	{
		if(!triggered && counting && (Time.time - startTime) > delay){
			TriggerChildren();
			if(triggerOnce){
				triggered = true;
			}
			counting = false;
		}
	}
}

