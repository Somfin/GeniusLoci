using UnityEngine;
using System.Collections;

public class LinearFade : MonoBehaviour {
	public Light myLight;
	public float lifespan;

	private float baseIntensity;
	private float lifetime;
	private float power;

	// Use this for initialization
	void Start () {
		baseIntensity = myLight.intensity;
	}
	
	// Update is called once per frame
	void Update () {
		lifetime += Time.deltaTime;
		if (lifetime > lifespan) {
			GameObject.Destroy (gameObject);
		}
		power = (lifespan - lifetime) / lifespan;
		myLight.intensity = baseIntensity * power;
	}
}
