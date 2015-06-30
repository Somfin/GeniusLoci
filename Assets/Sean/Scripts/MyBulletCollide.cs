//This is primarily Woody's code, but I changed a few lines
using UnityEngine;
using System.Collections;

public class MyBulletCollide : MonoBehaviour {

	public GameObject bang;
	public GameObject particles;

	private GameObject player;
	private GameObject creator;
	private bool active;

	
	// Use this for initialization
	void Start () {
		active = true;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnCollisionEnter(Collision collision) {
		Collider other = collision.collider;
		if (other.tag == "Enemy" && active) {
			GameObject.Instantiate (bang, gameObject.transform.position, gameObject.transform.rotation);
			other.GetComponent<CreatureHealth> ().takeDamage (1);
			GetComponent<MyBulletKill> ().die ();
		} else if (other.tag == "Pull" && active) {
			GetComponent<MyBulletKill> ().die ();
			creator.GetComponent<PlayerPuller> ().pullTo (other.gameObject);
		
		} else if (other.tag == "Charger" && active) { //My code starts here

			player.GetComponent<PlayerBattery>().charge(particles);
			GetComponent<MyBulletKill>().die();
		}												//My code ends here
		Physics.IgnoreCollision (GetComponent<Collider> (), other);
	}
	
	public void setCreator(GameObject obj){
		creator = obj;
	}
}
