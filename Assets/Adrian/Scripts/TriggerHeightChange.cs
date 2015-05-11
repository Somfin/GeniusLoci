using UnityEngine;
using System.Collections;

public class TriggerHeightChange : TriggerBase
{
	public float shiftDistance;
	public float speed;
	public float dampening = 0.1f;

	private bool moving = false;
	private Vector3 start;
	private Vector3 target;
	private float startTime;
	private float journeyLength;

	void Start(){
	}

	public override void Activate(){
		startTime = Time.time;
		start = transform.position;
		target = new Vector3 (transform.position.x, transform.position.y + shiftDistance, transform.position.z);
		journeyLength = Vector3.Distance (transform.position, target);
		moving = true;
	}

	
	void Update ()
	{
		if (moving) {
			float distCovered = (Time.time - startTime) * speed * dampening;
			float fracJourney = distCovered / journeyLength;
			Debug.Log(fracJourney);
			transform.position = Vector3.Lerp(start, target, fracJourney);
			if(fracJourney >= 1){
				moving = false;
				TriggerChildren();
			}

			//TODO(Adriant): Handle collision with player.
		}
	}
}

