using UnityEngine;
using System.Collections;

public class ChaosTwitch: MonoBehaviour {
	public float Twitchiness;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate(Random.insideUnitSphere * Twitchiness);
	}
}
