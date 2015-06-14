using UnityEngine;
using System.Collections;

public class CountTrigger : TriggerBase
{
	public int count;
	public bool triggerOnce = true;
	public bool resetOnTrigger = false;

	private int activated = 0;
	private bool triggered = false;


	public override void Activate(){
		activated++;

		if (!triggered && activated >= count) {
			TriggerChildren ();
			if(resetOnTrigger){
				activated = 0;
			} else if (triggerOnce) {
				triggered = true;
			}

		}
	}
}
