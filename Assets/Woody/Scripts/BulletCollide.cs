using UnityEngine;
using System.Collections;

public class BulletCollide : MonoBehaviour {
	public GameObject bang;
	public GameObject particles;

	private bool active;

	// Use this for initialization
	void Start () {
		active = true;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy" && active) {
			GameObject.Instantiate (bang, gameObject.transform.position, gameObject.transform.rotation);
			other.GetComponent<CreatureHealth>().takeDamage(1);
			GetComponent<BulletKill>().die();
		}
	}
}
