using UnityEngine;
using System.Collections;

public class DustScript : MonoBehaviour {

	private GameObject parent;
	private ParticleSystem particleSystem;
	private Renderer parentRenderer;
	private Vector3 particlePosition;
	private Collider col;

	private Vector3 boundPoint1;
	private Vector3 boundPoint2;
	private Vector3 boundPoint3;
	private Vector3 boundPoint4;
	private Vector3 boundPoint5;
	private Vector3 boundPoint6;
	private Vector3 boundPoint7;
	private Vector3 boundPoint8;
	// Use this for initialization
	void Start () {
	
		parent = GetComponentInParent<GameObject> ();
		particleSystem = GetComponent<ParticleSystem> ();
		parentRenderer = GetComponentInParent<Renderer> ();
		col = GetComponentInParent<Collider> ();

		findPoints ();

	}

	// Update is called once per frame
	void Update () {
	

	}

	void findPoints() {

		boundPoint1 = col.bounds.min;
		boundPoint2 = col.bounds.max;
		boundPoint3 = new Vector3(boundPoint1.x, boundPoint1.y, boundPoint2.z);
		boundPoint4 = new Vector3(boundPoint1.x, boundPoint2.y, boundPoint1.z);
		boundPoint5 = new Vector3(boundPoint2.x, boundPoint1.y, boundPoint1.z);
		boundPoint6 = new Vector3(boundPoint1.x, boundPoint2.y, boundPoint2.z);
		boundPoint7 = new Vector3(boundPoint2.x, boundPoint1.y, boundPoint2.z);
		boundPoint8 = new Vector3(boundPoint2.x, boundPoint2.y, boundPoint1.z);

		debugLines ();

	}

	void debugLines()
	{
		//if you want to visualize the box you can add to MrSkiz's code:
		Color lineColor = Color.green;
		// rectangular cuboid
		// top of rectangular cuboid (6-2-8-4)
		Debug.DrawLine (boundPoint6, boundPoint2, lineColor);
		Debug.DrawLine (boundPoint2, boundPoint8, lineColor);
		Debug.DrawLine (boundPoint8, boundPoint4, lineColor);
		Debug.DrawLine (boundPoint4, boundPoint6, lineColor);
		
		// bottom of rectangular cuboid (3-7-5-1)
		Debug.DrawLine (boundPoint3, boundPoint7, lineColor);
		Debug.DrawLine (boundPoint7, boundPoint5, lineColor);
		Debug.DrawLine (boundPoint5, boundPoint1, lineColor);
		Debug.DrawLine (boundPoint1, boundPoint3, lineColor);
		
		// legs (6-3, 2-7, 8-5, 4-1)
		Debug.DrawLine (boundPoint6, boundPoint3, lineColor);
		Debug.DrawLine (boundPoint2, boundPoint7, lineColor);
		Debug.DrawLine (boundPoint8, boundPoint5, lineColor);
		Debug.DrawLine (boundPoint4, boundPoint1, lineColor);

	}
}
