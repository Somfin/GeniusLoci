using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class TriggerSpeaker : TriggerBase {

	public AudioClip sound;

	private bool playing = false;
	private float startTime;
	private bool triggered = false;

	public override void Activate()
	{
		if (!playing)
		{
			this.GetComponent<AudioSource>().clip = sound;			
			this.GetComponent<AudioSource>().Play();
			playing = true;
			startTime = Time.time;
		}
	}

	void Update ()
	{
		if(!triggered && playing){
			if((Time.time - startTime) > sound.length){
				TriggerChildren();
			}
		}
	}
}
