using UnityEngine;
using System.Collections;

public class FogChanger : MonoBehaviour {
	public float fogStart;
	public float fogEnd;

	// Use this for initialization
	void Start () {
		RenderSettings.fog = true;
		RenderSettings.fogMode = FogMode.Linear;
		RenderSettings.fogStartDistance = fogStart;
		RenderSettings.fogEndDistance = fogEnd;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
