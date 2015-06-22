using UnityEngine;
using System.Collections;

public class ConstantSpin : MonoBehaviour {
	public float xTurnRate;
	public float yTurnRate;
	public float zTurnRate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		gameObject.transform.Rotate (new Vector3 (xTurnRate * Time.deltaTime, 0f, 0f));
		gameObject.transform.Rotate (new Vector3 (0f, yTurnRate * Time.deltaTime, 0f));
		gameObject.transform.Rotate (new Vector3 (0f, 0f, zTurnRate * Time.deltaTime));
	}
}
