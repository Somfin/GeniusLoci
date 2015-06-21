using UnityEngine;
using System.Collections;

public class TriggerFogChange : TriggerBase {
	public float targetDensity;
	public float changeRate;
	public float currentDensity;
	public Color targetColor;
	public bool fogActive;
	public bool changing;

	// Use this for initialization
	public override void Activate(){
		changing = true;
	}

	void Update(){
		currentDensity = RenderSettings.fogDensity;
		if (changing) {
			if (!RenderSettings.fog){
				RenderSettings.fogDensity = 0.000000001f;
			}
			RenderSettings.fog = fogActive;
			if (Mathf.Abs (RenderSettings.fogDensity - targetDensity) > 0.00001){
				RenderSettings.fogDensity = Mathf.Lerp (RenderSettings.fogDensity, targetDensity, changeRate);
				RenderSettings.fogColor = Color.Lerp (RenderSettings.fogColor, targetColor, changeRate);
			} else {
				RenderSettings.fogDensity = targetDensity;
				changing = false;
				TriggerChildren ();
			}
		}
	}
}
