using UnityEngine;
using System.Collections;

public class SlowSpin : MonoBehaviour {
	public float turnRate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		gameObject.transform.Rotate (new Vector3 (0, turnRate * Time.deltaTime, 0));
	}
}
