using UnityEngine;
using System.Collections;

public class TeleportPlayer : TriggerBase
{
	
	public Transform target;

	public override void Activate(){
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		player.transform.position = target.position;
		TriggerChildren ();
	}
}

