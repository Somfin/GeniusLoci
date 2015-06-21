using UnityEngine;
using System.Collections;

public class TriggerLightChange: TriggerBase {
	public Light targetLight;
	public float newIntensity;
	public float shiftRate;
	public bool changing;

	// Use this for initialization
	void Start () {
	
	}
	
	public override void Activate(){
		changing = true;
	}

	void Update(){
		if (changing) {
			if (Mathf.Abs (targetLight.intensity - newIntensity) > 0.0001){
				targetLight.intensity = Mathf.Lerp (targetLight.intensity, newIntensity, shiftRate);
			} else {
				targetLight.intensity = newIntensity;
				changing = false;
				TriggerChildren ();
			}
		}
	}
}
