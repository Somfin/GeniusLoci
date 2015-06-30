//This is primarily Woody's code, but I changed a few lines
using UnityEngine;
using System.Collections;

public class MyBulletKill : MonoBehaviour {

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
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		GetComponent<Light> ().enabled = false;

		GetComponent<MyBulletCollide> ().enabled = false;
		
		Destroy (bullet);
		particles.GetComponent<ParticleSystem>().Stop();
	}
}