using UnityEngine;
using System.Collections;

public class TriggerShiftRewind : TriggerBase
{
	public float xShift;
	public float yShift;
	public float zShift;
	public float speedForward;
	public float speedBack;
	public bool stopOnMax = false;
	
	private Vector3 start;
	private Vector3 target;
	private float startTime;
	private float journeyLength;
	private float journeyPosition = 0.0f;
	private bool done = false;
	
	void Start(){
		start = transform.position;
		target = new Vector3 (transform.position.x + xShift, transform.position.y + yShift, transform.position.z + zShift);
		journeyLength = Vector3.Distance (transform.position, target);
	}
	
	public override void Activate(){

		if (!done) {
			journeyPosition+= 0.0001f * speedForward;
			startTime = Time.time;
			if(journeyPosition > 1){
				journeyPosition = 1.0f;
			}
		}
	}
	
	
	void FixedUpdate ()
	{
		if (!done && journeyPosition >= 0) {
			transform.position = Vector3.Lerp(start, target, journeyPosition);

			if(journeyPosition >= 1){
				TriggerChildren();
				if(stopOnMax){
					done = true;
				}
			}

			if(!done && (Time.time - startTime) > 0.05f){
				journeyPosition-= 0.0001f * speedBack;
				if(journeyPosition < 0){
					journeyPosition = 0.0f;
				}
			}
		}
	}
}

