using UnityEngine;
using System.Collections;

public class CreatureTargeting : MonoBehaviour {
	private NavMeshAgent agent;
	private GameObject target;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		target = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, target.transform.position) < 40f) {
			agent.SetDestination (target.transform.position);
		}
	}
}
