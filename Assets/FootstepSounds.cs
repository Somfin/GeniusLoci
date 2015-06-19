using UnityEngine;
using System.Collections;

public class FootstepSounds : MonoBehaviour {
	public AudioClip[] footsteps;
	public Animation[] walking;
	public Animator anim;
	public AudioSource source;
	private bool left;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Animation a in walking) {
			if (a.isPlaying) {
				if (left && anim.GetCurrentAnimatorStateInfo (0).normalizedTime % 1 > .25f) {
					Footstep ();
					left = false;
				}
				else if (anim.GetCurrentAnimatorStateInfo (0).normalizedTime % 1 > .75f) {
					Footstep ();
					left = true;
				}
			}
		}
	
	}

	void Footstep() {
		int step = Mathf.FloorToInt(Random.value * footsteps.Length);
		source.clip = ((AudioClip)footsteps[step]);
		source.Stop ();
		source.Play ();
	}
}
