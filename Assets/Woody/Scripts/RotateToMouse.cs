using UnityEngine;
using System.Collections;

public class RotateToMouse : MonoBehaviour {
	public float horizTurn;
	public float vertTurn;

	private bool clicked;

	// Use this for initialization
	void Start () {
		clicked = false;
	}
	
	// Update is called once per frame
	void Update () {
		float x = horizTurn * Input.GetAxis ("Mouse X");
		transform.Rotate (0, x, 0);
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
