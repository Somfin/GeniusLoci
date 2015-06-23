using UnityEngine;
using System.Collections;

public class FinalTowerZoomOut : MonoBehaviour {
	
	private bool startScene = false;

	
	public GameObject lookAtStart;
	public GameObject lookAtFinish;
	public float lookAtSmooth = 1.5f;

	public GameObject destination;
	public float smooth = 1.5f;

	//private Camera main;

	private bool isCheckingInput = false;

	private bool hasBeenTriggered = false;
	private GameObject player;

	private Vector3 lookAtStartPosition;
	//private GameObject crosshair;
	private Crosshair crosshairScript;


	private AudioSource backgroundMusic;
	private AudioSource zoomMusic;

	bool changeSound = true;

	void Start () {
	
		player = GameObject.FindGameObjectWithTag ("Player");
		//crosshair = GameObject.FindGameObjectWithTag ("Crosshair");
		crosshairScript = player.GetComponent<Crosshair> ();

		backgroundMusic = GameObject.FindGameObjectWithTag ("BackgroundMusic").GetComponent<AudioSource> ();
		zoomMusic = GetComponent<AudioSource> ();

			//player.GetComponentInParent<AudioSource> ();
	}

	void Update () {

		if (isCheckingInput) {

			if(Input.anyKeyDown){

				EndScene();
			}
		}
	
	}


	void OnTriggerEnter(Collider other) {

		if (other.tag == "Player" && !hasBeenTriggered) {

			Camera.main.GetComponent<CameraControl>().enabled = false;

			crosshairScript.crosshairImage.enabled = false;

			hasBeenTriggered = true;
			startScene = true;

			if(changeSound){
				backgroundMusic.mute = true;
				zoomMusic.Play();
				zoomMusic.time = 3;
			}

			lookAtStartPosition = lookAtStart.transform.position;
		}
	}
	
	
	void FixedUpdate () {

		if (startScene) {

			StartCoroutine(EndSceneTimer());
			StartCoroutine(CheckInput());

			Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, destination.transform.position, smooth * Time.deltaTime);


			lookAtStartPosition = Vector3.Lerp(lookAtStartPosition, lookAtFinish.transform.position, lookAtSmooth * Time.deltaTime);

			Camera.main.transform.LookAt (lookAtStartPosition);

		}
	
	}

	IEnumerator EndSceneTimer(){

		yield return new WaitForSeconds(8);

		EndScene ();

	}

	IEnumerator CheckInput(){

		yield return new WaitForSeconds(1);

		isCheckingInput = true;
	}

	void EndScene()
	{
		if (changeSound) {
			zoomMusic.volume = zoomMusic.volume / 2f;
			backgroundMusic.mute = false;
		}

		crosshairScript.crosshairImage.enabled = true;
		Camera.main.GetComponent<CameraControl> ().enabled = true;


	}
}
