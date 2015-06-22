using UnityEngine;
using System.Collections;

public class RunBob : MonoBehaviour {
	public float liftDampen;
	public float liftOffset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float lift = gameObject.GetComponent<Animator> ().GetFloat ("Lift") * liftDampen;
		transform.position = new Vector3 (transform.parent.transform.position.x, transform.parent.transform.position.y + lift + liftOffset, transform.parent.transform.position.z);
	}
}
