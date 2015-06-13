using UnityEngine;
using System.Collections;

public class NewBurner : MonoBehaviour {

	public float flipNum = 80f;

	public float rotationSpeed = 30f;
	private GameObject player;
	
	public float maxSpeed = 32f;
	public float minSpeed = 16f;

	public float maxSize = 2f;
	public float minSize = .7f;

	private float tempSpeed;
	private float tempSize;
	
	private PlayerMover playerMover;
	private ParticleSystem partSys;

	private float speedRange;
	private float sizeRange;
	// Use this for initialization
	
	private float h, v; //Input values
	private Vector3 rotation;

	private Quaternion toRotation;

	private Vector3 targetPoint;

	void Start () {
		
		player = GameObject.FindGameObjectWithTag ("Player");


		partSys = gameObject.GetComponent<ParticleSystem> ();
		playerMover = player.GetComponent<PlayerMover> ();

		partSys.enableEmission = false;
		partSys.Play ();
		//partSys.Stop ();

		speedRange = maxSpeed - minSpeed;
		sizeRange = maxSize - minSize;

		rotation.Set (90f, 0f, 0f);
		transform.localEulerAngles = rotation;

		toRotation = Quaternion.LookRotation (new Vector3 (0f, -100f, 0f)); 
	}
	
	// Update is called once per frame
	void Update () {

		h = Input.GetAxisRaw ("Horizontal");
		v = Input.GetAxisRaw ("Vertical");

		if (playerMover.jumpHold) {
			tempSpeed = minSpeed + (speedRange * (playerMover.currentJump / playerMover.jumpRate));
			partSys.startSpeed = tempSpeed;

			tempSize = minSize + (sizeRange * (playerMover.currentJump / playerMover.jumpRate));
			partSys.startSize = tempSize;
		} else {
			//partSys.Stop ();
			partSys.enableEmission = false;
		}

		setRotation ();
	
		if (playerMover.jumping && playerMover.jumpHold) {

			//if(partSys.isStopped)
			if(!partSys.enableEmission) //No emission
				transform.rotation = toRotation;
			else
				transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
			
			//if (partSys.isStopped)
				//partSys.Play ();

			//if (!partSys.enableEmission)
			partSys.enableEmission = true;

		} else {
			//partSys.Stop ();
			//partSys.Clear();
			partSys.enableEmission = false;
		}

	}
	

	void setRotation() {

		if (playerMover.jumpHold)
			rotation.y = -100f;
		else
			rotation.y = -50f;


		rotation.x = h * -100f;

		rotation.z = v * -100f;

		targetPoint = player.transform.TransformPoint (rotation);


		toRotation = Quaternion.LookRotation (targetPoint - transform.position, transform.up);

	}
}
