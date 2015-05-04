using UnityEngine;
using System.Collections;

public class NewCameraController : MonoBehaviour {

	public GameObject player;

	public float distanceAway;
	public float distanceUp;
	public float smooth;
	public Vector3 offset = new Vector3(0f, 1.5f, 0f);

	//smoothing and damping
	public Vector3 velocityCamSmooth = Vector3.zero;
	public float camSmoothDampTime = 0.1f;

	private Transform followXForm;
	private Vector3 targetPosition;
	private Vector3 lookDir;

	// Use this for initialization
	void Start () {
	
		followXForm = player.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {

		Vector3 characterOffset = followXForm.position + offset;

		lookDir = characterOffset - this.transform.position;
		lookDir.y = 0;
		lookDir.Normalize();

		targetPosition = characterOffset + followXForm.up * distanceUp - lookDir * distanceAway;



		smoothPosition (this.transform.position, targetPosition);
	

		//Makes sure is looking the right way

		transform.LookAt (followXForm);

	}

	private void smoothPosition(Vector3 fromPos, Vector3 toPos){
		this.transform.position = Vector3.SmoothDamp (fromPos, toPos, ref velocityCamSmooth, camSmoothDampTime);
	}
}
