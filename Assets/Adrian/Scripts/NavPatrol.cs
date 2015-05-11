using UnityEngine;
using System.Collections;

public class NavPatrol : MonoBehaviour {

	public Transform[] waypoints = {};
	int destination;
	NavMeshAgent agent;

	public float threshold = 2.0f;
	public float chase_threshold = 6.0f;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		destination = 0;
		agent.SetDestination (waypoints[destination].position);

	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (transform.position, waypoints [destination].position);

		if (distance < threshold) {
			destination++;

			if(destination >= waypoints.Length){
				destination = 0;
			}
			agent.SetDestination (waypoints[destination].position);	
		}

		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		
		distance = Vector3.Distance (player.transform.position, transform.position);
		
		if (distance < chase_threshold) {
			agent.SetDestination (player.transform.position);
		} else {
			agent.SetDestination (waypoints[destination].position);
		}

	}
}
