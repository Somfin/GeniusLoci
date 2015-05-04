using UnityEngine;
using System.Collections;

public class RotateToMouse : MonoBehaviour {
	public float horizTurn;
	public float vertMove;

	private bool clicked;
	private Vector3 rotX;
	private Vector3 rotY;

	// Use this for initialization
	void Start () {
		clicked = false;
	}
	
	// Update is called once per frame
	void Update () {
		float x = horizTurn * Input.GetAxis ("Mouse X");
		float y = -vertMove * Input.GetAxis ("Mouse Y");
		rotX = new Vector3(0, x, 0);
		rotY = new Vector3(0, y, 0);
		transform.Rotate (rotX);
		transform.Translate (rotY);
		if (Input.GetAxisRaw ("Fire2") == 1){
			transform.rotation = transform.parent.rotation;
		}
		if (Input.GetAxisRaw ("Fire1") == 1) {
			transform.parent.rotation = transform.rotation;
			transform.rotation = transform.parent.rotation;
			clicked = true;
		}
		if (Input.GetAxisRaw ("Fire1") == 0 && clicked) {
			clicked = false;
		}
	}
}
