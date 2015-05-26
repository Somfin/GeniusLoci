using UnityEngine;
using System.Collections;

public class SpawnPrefab : TriggerBase
{
	
	public Transform target;
	public GameObject prefab;
	
	public override void Activate(){
		Instantiate(prefab, target.position, Quaternion.identity);
		TriggerChildren ();
	}
}

