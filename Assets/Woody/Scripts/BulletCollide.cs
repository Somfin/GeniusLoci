using UnityEngine;
using System.Collections;

public class BulletCollide : MonoBehaviour {
	public GameObject bang;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy") {
			GameObject.Instantiate (bang, gameObject.transform.position, gameObject.transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
