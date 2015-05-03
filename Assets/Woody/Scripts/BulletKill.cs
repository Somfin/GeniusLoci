using UnityEngine;
using System.Collections;

public class BulletKill : MonoBehaviour {
	public GameObject particles;
	public GameObject bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void die(){
		Destroy (gameObject, 1.0f);
		GetComponent<BulletMove> ().movementSpeed = 0;
		GetComponent<Light> ().enabled = false;
		GetComponent<BulletCollide> ().enabled = false;
		Destroy (bullet);
		particles.GetComponent<ParticleSystem>().Stop();
	}
}
