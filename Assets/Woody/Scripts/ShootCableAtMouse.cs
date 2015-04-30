using UnityEngine;
using System.Collections;

public class ShootCableAtMouse : MonoBehaviour {
	public GameObject bullet;
	public GameObject cable;
	private bool firing;
	private bool fired;
	private GameObject currentBullet;


	// Use this for initialization
	void Start () {
		firing = false;
		fired = false;
		currentBullet = null;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw ("Fire1") == 1) {
			firing = true;
		} else {
			firing = false;
			fired = false;
		}
		if (currentBullet != null){
			Debug.DrawLine (gameObject.transform.position, currentBullet.transform.position, Color.black);
		}
	}

	void FixedUpdate () {
		if (firing && !fired && currentBullet != null) {
			GameObject.Destroy (currentBullet);
			currentBullet = null;
		}
		if (firing && !fired) {
			fired = true;
			GameObject newBullet = GameObject.Instantiate (bullet, transform.position, transform.rotation) as GameObject;
			currentBullet = newBullet;
		}
	}

	void OnGUI() {
		if (fired) {
			GUI.Label (new Rect (0, 0, Screen.width, Screen.height), "...");
		} else if (firing) {
			GUI.Label (new Rect (0, 0, Screen.width, Screen.height), "BANG!");
		} else {
			GUI.Label (new Rect (0, 0, Screen.width, Screen.height), "Wait for it...");
		}
	}
}
