using UnityEngine;
using System.Collections;

/**
 * Triggerable objects are those which react to some trigger
 * Triggerable objects should override the Activate method, which is called when they are triggered
 */ 

[System.Serializable]
public abstract class TriggerableObject : MonoBehaviour
{
	public virtual void Activate()
	{
	}
}
