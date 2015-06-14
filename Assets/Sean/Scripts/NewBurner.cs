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


	//Light stuff below
	private Light jetPackLight;
	public float maxLightIntensity = 5f;
	public float minLightIntensity = 1f;


	void Start () {
		
		player = GameObject.FindGameObjectWithTag ("Player");


		partSys = gameObject.GetComponent<ParticleSystem> ();
		playerMover = player.GetComponent<PlayerMover> ();


		jetPackLight = GetComponent<Light> ();
		jetPackLight.enabled = false;


		partSys.enableEmission = false;
		partSys.Play ();

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
			partSys.enableEmission = false;
		}

		setRotation ();
	
		if (playerMover.jumping && playerMover.jumpHold) {

			if(!partSys.enableEmission) //No emission
				transform.rotation = toRotation;
			else
				transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

			if(playerMover.currentJump > 1)
				partSys.enableEmission = true;

		} else {
			partSys.enableEmission = false;
		}

		AddLight ();

	}
	
	void AddLight()
	{
		float lightRange = maxLightIntensity - minLightIntensity;
		//jetPackLight.intensity = minLightIntensity + (lightRange * (playerMover.currentJump / playerMover.jumpRate));

		//if(partSys.
		if (partSys.particleCount > 0) {

			//jetPackLight.intensity = partSys.particleCount/5;

			if(!playerMover.jumpHold)
				jetPackLight.intensity = jetPackLight.intensity * (partSys.particleCount/80);
			else
				jetPackLight.intensity = minLightIntensity + (lightRange *  (playerMover.currentJump / playerMover.jumpRate));

			if (!jetPackLight.enabled)
				jetPackLight.enabled = true;

		} else
			jetPackLight.enabled = false;

	}


	void setRotation() {

		if (playerMover.jumpHold)
			rotation.y = -100f;
		else
			rotation.y = -50f;


		//rotation.x = h * -100f;
		rotation.x = h * -50f;

		//rotation.z = v * -100f;
		rotation.z = v * -50f;

		if (rotation.z > 0) //Preventing jetpack from hitting player
			rotation.z = 0;

		targetPoint = player.transform.TransformPoint (rotation);


		toRotation = Quaternion.LookRotation (targetPoint - transform.position, transform.up);

	}
}
