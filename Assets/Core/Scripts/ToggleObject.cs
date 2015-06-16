using UnityEngine;
using System.Collections;

public class ToggleObject : TriggerBase
{
	
	public GameObject target;
	public bool start_disabled = false;

	void Start(){
		target.SetActive (!start_disabled);
	}
	
	public override void Activate(){
		target.SetActive (!target.activeSelf);
		TriggerChildren ();
	}
}

