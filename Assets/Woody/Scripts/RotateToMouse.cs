using UnityEngine;
using System.Collections;

public class RotateToMouse : MonoBehaviour {
	public float horizTurn;
	public float vertMove;
	public float miny;
	public float maxy;
	public GameObject anchor;

	private bool clicked;
	private Vector3 moveTo;
	private Vector3 rotY;
	private Vector3 movY;

	// Use this for initialization
	void Start () {
		clicked = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float x = horizTurn * Input.GetAxis ("Mouse X");
		float y = -vertMove * Input.GetAxis ("Mouse Y");
		movY = new Vector3(0, y, 0);
		rotY = new Vector3(0, x, 0);
		moveTo = anchor.transform.position + movY;
		if (moveTo.y - transform.position.y > maxy) {
			moveTo = new Vector3 (moveTo.x, maxy + transform.position.y, moveTo.z);
		} else if (moveTo.y - transform.position.y  < miny){
			moveTo = new Vector3 (moveTo.x, miny + transform.position.y, moveTo.z);
		}

		anchor.transform.position = moveTo;
		transform.Rotate (rotY);
	}
}
