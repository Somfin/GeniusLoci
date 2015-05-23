using UnityEngine;
using System.Collections;

public class ToggleObject : TriggerBase
{
	
	public GameObject target;
	
	public override void Activate(){
		target.SetActive (!target.activeSelf);
		TriggerChildren ();
	}
}

