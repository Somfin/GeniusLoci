using UnityEngine;
using System.Collections;

public class EnemyTrigger : MonoBehaviour {

	public GameObject obj;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			this.gameObject.SendMessageUpwards ("Spawn");
		}
	}
}
