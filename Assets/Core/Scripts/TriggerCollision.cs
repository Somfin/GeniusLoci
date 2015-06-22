using UnityEngine;
using System.Collections;

public class TriggerCollision : TriggerBase
{
	public string triggeredByTag = "Player";
	public bool repeat = true;
	public bool hideMesh = true;
	public bool triggerOnce = true;

	public TriggerBase[] childrenOnExit = {};

	private bool triggered = false;

	void Start ()
	{
		if (hideMesh) {
			GetComponent<Renderer> ().enabled = false;
		}
	}

	// Can be triggered directly if needed by another trigger.
	public override void Activate(){
		if (!triggerOnce || !triggered) {
			TriggerChildren ();
			triggered = true;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		Go (other);
	}

	void OnTriggerStay (Collider other)
	{
		if (repeat)
			Go (other);
	}

	void OnTriggerExit (Collider other)
	{
		foreach (TriggerBase child in childrenOnExit)
		{
			child.Activate();
		}
	}

	void Go (Collider other)
	{
		if (!triggerOnce || !triggered) {
			if (other.gameObject.tag.Equals (triggeredByTag)) {
				TriggerChildren ();
				triggered = true;
			}
		}
	}
}
