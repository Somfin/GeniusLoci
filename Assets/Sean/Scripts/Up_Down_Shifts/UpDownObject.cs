using UnityEngine;
using System.Collections;

public class UpDownObject : MonoBehaviour {

	public float upY;
	public float downY;
	public float speed;
	public float dampening = 0.05f;

	public bool isUp = false;

	public bool isLocked = false;

	public bool moving = true;
	public float percentCovered = 0f;


	private Vector3 start;
	private Vector3 target;
	private float startTime;
	private float journeyLength;

	//public UpDownObject[] collection = {};

	// Use this for initialization
	void Start () {

		start = transform.localPosition;
		target = transform.localPosition;
		if (isUp)
			target.y = upY;
		else
			target.y = downY;
	
		startTime = Time.time;

		//journeyLength = 0;
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (moving) {

			float distCovered = (Time.time - startTime) * speed * dampening;
			float fracJourney = distCovered / journeyLength;

			percentCovered = fracJourney;

			transform.localPosition = Vector3.Lerp(start, target, fracJourney);
			if(fracJourney >= 1){
				moving = false;
			}

		}

	}

	public void Down()
	{
		if (isUp) {
			isUp = false;
			moving = true;

			startTime = Time.time;
			start = transform.localPosition;
			target = transform.localPosition;
			target.y = downY;

			journeyLength = Vector3.Distance (transform.localPosition, target);
		}
	}

	public void Up()
	{
		if (!isUp) {
			isUp = true;
			moving = true;

			startTime = Time.time;
			start = transform.localPosition;
			target = transform.localPosition;
			target.y = upY;

			journeyLength = Vector3.Distance (transform.localPosition, target);
		}
	}

	/*public void LowerAllButUp(){

		foreach(UpDownObject obj in collection){
			if(

	}*/

}
