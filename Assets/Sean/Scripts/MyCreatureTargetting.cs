//This is primarily Woody's code, but I changed a few lines
using UnityEngine;
using System.Collections;

public class MyCreatureTargetting : MonoBehaviour {

	private NavMeshAgent agent;
	private GameObject target;
	private Animator anim;
	
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		target = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, target.transform.position) < 40f) {
			anim.SetBool ("isMoving", true);
			agent.SetDestination (target.transform.position);
		} else
			anim.SetBool ("isMoving", false);
	}
}
