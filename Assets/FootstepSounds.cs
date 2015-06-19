using UnityEngine;
using System.Collections;

public class FootstepSounds : MonoBehaviour {
	public AudioClip[] footsteps;
	public AudioSource source;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Footstep() {
		int step = Mathf.FloorToInt(Random.value * footsteps.Length);
		source.clip = ((AudioClip)footsteps[step]);
		source.Stop ();
		source.Play ();
	}
}
