using UnityEngine;
using System.Collections;

public class TeleportObject : TriggerBase
{

	public Transform target;
	public Transform object_to_move;

	public override void Activate(){
		object_to_move.position = target.position;
		TriggerChildren ();
	}
}

