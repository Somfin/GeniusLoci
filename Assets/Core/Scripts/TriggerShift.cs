using UnityEngine;
using System.Collections;

public class TriggerShift : TriggerBase
{
	public float xShift;
	public float yShift;
	public float zShift;
	public float speed;
	public float dampening = 0.05f;
	
	public bool moving = false;

	public float percentCovered = 0f;

	private Vector3 start;
	private Vector3 target;
	private float startTime;
	private float journeyLength;
	
	void Start(){
	}
	
	public override void Activate(){
		startTime = Time.time;
		start = transform.position;
		target = new Vector3 (transform.position.x + xShift, transform.position.y + yShift, transform.position.z + zShift);
		journeyLength = Vector3.Distance (transform.position, target);
		moving = true;
	}
	
	
	void Update ()
	{
		if (moving) {
			float distCovered = (Time.time - startTime) * speed * dampening;
			float fracJourney = distCovered / journeyLength;

			percentCovered = fracJourney;

			transform.position = Vector3.Lerp(start, target, fracJourney);
			if(fracJourney >= 1){
				moving = false;
				TriggerChildren();
			}
		}
	}
}

