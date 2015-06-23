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
	
	void Start () {
	
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update () {

		if (isCheckingInput) {

			Debug.Log("IsCheckingInput true");

			if(Input.anyKeyDown){

				EndScene();
			}
		}
	
	}


	void OnTriggerEnter(Collider other) {

		if (other.tag == "Player" && !hasBeenTriggered) {

			Camera.main.GetComponent<CameraControl>().enabled = false;

			hasBeenTriggered = true;
			startScene = true;

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

		yield return new WaitForSeconds(6);

		EndScene ();

	}

	IEnumerator CheckInput(){

		yield return new WaitForSeconds(1);

		isCheckingInput = true;
	}

	void EndScene()
	{

		Camera.main.GetComponent<CameraControl> ().enabled = true;


	}
}
