using UnityEngine;
using System.Collections;

public class PullHit : MonoBehaviour {
	public float maxSpin;
	public float maxIntensity;
	public float maxRange;
	public Light flare;
	public ConstantSpin spin;
	public AudioSource sound;
	private float currentSpin;
	private float baseSpin;
	private float currentIntensity;
	private float baseIntensity;
	private float currentRange;
	private float baseRange;

	// Use this for initialization
	void Start () {
		baseSpin = spin.turnRate;
		baseIntensity = flare.intensity;
		baseRange = flare.range;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate () {
		currentSpin = spin.turnRate;
		currentIntensity = flare.intensity;
		currentRange = flare.range;
		spin.turnRate = Mathf.Lerp (currentSpin, baseSpin, 0.01f); 
		flare.intensity = Mathf.Lerp (currentIntensity, baseIntensity, 0.01f);
		flare.range = Mathf.Lerp (currentRange, baseRange, 0.01f);
	}

	public void spinUp(){
		spin.turnRate = maxSpin;
		flare.intensity = maxIntensity;
		flare.range = maxRange;
		sound.Stop ();
		sound.Play ();
	}
}
