using UnityEngine;
using System.Collections;

/**
 * Trigger objects are objects which can activate other objects
 * All trigger objects should at some point call the TriggerChildren method below
 * All Trigger Objects are also triggerable, but most will not act when activated
 */
public abstract class TriggerBase : MonoBehaviour
{
	//The Triggerable objects which are activated when the trigger is tripped
	public TriggerBase[] children = {};

	public virtual void Activate()
	{
	}

	protected void TriggerChildren()
	{
		foreach (TriggerBase child in children)
		{
			child.Activate();
		}
	}
}