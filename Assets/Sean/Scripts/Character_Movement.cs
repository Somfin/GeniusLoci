using UnityEngine;
using System.Collections;

public class Character_Movement : MonoBehaviour {
	
	public float walkSpeed = 6.0f;
	public float runSpeed = 6.0f;
	public float gravity = 20.0f;
	public float standingRotateSpeed = 2.0f;
	public float walkRotateSpeed = 2.0f;
	public float runRotateSpeed = 1.0f;
	public float JumpSpeed = 100.0f;
	public float MaxTurnSpeed;


	public Camera gameCam;
	public float directionSpeed;

	private float speed;
	private float direction;

	private int m_LocomotionId = 0;
	public float rotationDegreePerSecond = 120f;

	private float isMoving;
//	private AnimatorStateInfo stateInfo;


	private bool isRunning = false;

	//public float VerticalLookSpeed = 2f;

	//private float VertLook;

	private Vector3 moveDirection = Vector3.zero;

	private float v = 0f;
	private float h = 0f;
	private bool jumpStarting = false;

	Animator anim;
	Rigidbody rBody;
	CharacterController controller;

	void Start(){
	//	m_LocomotionId = Animator.StringToHash ("Base Layer.Locomotion");
		anim = GetComponent<Animator> ();
		rBody = GetComponent<Rigidbody> ();
		controller = GetComponent<CharacterController>();
	}


	//Update is called once per frame
	void Update() {
	
		v = Input.GetAxis ("Vertical");
		h = Input.GetAxis ("Horizontal");

		//stateInfo = anim.GetCurrentAnimatorStateInfo ();

		StickToWorldSpace (this.transform, gameCam.transform, ref direction, ref speed);

		if(Input.GetKeyDown(KeyCode.Space)){
			isRunning = !isRunning;
		}
		if (v < .5){
			isRunning = false;
		}
		anim.SetBool ("isRunning", isRunning);

		if (Input.GetKeyDown (KeyCode.J) && controller.isGrounded)
			jumpStarting = true;
		else
			jumpStarting = false;

	}

	void FixedUpdate() {
		if (controller.isGrounded) {

			if((h<-.05 || h > .5)){
				if(v >= -.5)
					moveDirection = new Vector3 (0, 0, 1);
				else
					moveDirection = new Vector3 (0, 0, -1);
			}else
				moveDirection = new Vector3 (0, 0, v);

			isMoving = moveDirection.z;

			//moveDirection = new Vector3(h, 0f, v);
			//moveDirection = new Vector3(0, 0f, v);

			moveDirection = transform.TransformDirection (moveDirection);
			
			if (isRunning){
				moveDirection *= runSpeed;
			} else {
				moveDirection *= walkSpeed;
			}

		}
		//if(h>.5||h<-.5)
		//	Rotate ();

		if (jumpStarting)
			moveDirection.y = JumpSpeed;

		moveDirection.y -= gravity * Time.deltaTime;

		controller.Move (moveDirection * Time.deltaTime);



		//Vector3 modMoveDirection = moveDirection;
		Vector3 modMoveDirection = new Vector3 (h, 0, v);
		modMoveDirection = transform.TransformDirection (modMoveDirection);
		modMoveDirection.y = 0;
		Vector3 modPosition = transform.position;
		modPosition.y = 0;

		if (modMoveDirection != Vector3.zero) {
			Quaternion wantedRotation = Quaternion.LookRotation (modMoveDirection);
			transform.rotation = Quaternion.RotateTowards (transform.rotation, wantedRotation, MaxTurnSpeed * Time.deltaTime);
		}




		if (((direction >= 0 && h >= 0) || (direction < 0 && h < 0))) {
			Vector3 rotationAmount = Vector3.Lerp (Vector3.zero, new Vector3 (0f, rotationDegreePerSecond * (h < 0f ? -1f : 1f), 0f), Mathf.Abs (h));
			Quaternion deltaRotation = Quaternion.Euler (rotationAmount * Time.deltaTime);
		}


		//Quaternion wantedRotation = Quaternion.LookRotation (new Vector3(h, 0, v));
		//transform.rotation = Quaternion.RotateTowards(transform.rotation, wantedRotation, MaxTurnSpeed * Time.deltaTime);

		anim.SetFloat ("isMoving", isMoving);
	}
	

/*	void Rotate() {

		if (v > -.5 && v < .5) {
			transform.Rotate (0, h * standingRotateSpeed, 0);
		} else {
			if (!isRunning) {
				transform.Rotate (0, h * walkRotateSpeed, 0);
			}else{
				transform.Rotate (0, h * runRotateSpeed, 0);
			}
		}
	}*/

	void StickToWorldSpace(Transform root, Transform camera, ref float directionOut, ref float speedOut){

		Vector3 rootDirection = root.forward;

		Vector3 stickDirection = new Vector3 (h, 0, v);

		speedOut = stickDirection.sqrMagnitude;

		Vector3 cameraDirection = camera.forward;
		cameraDirection.y = 0.0f;
		Quaternion referentialShift = Quaternion.FromToRotation (Vector3.forward, cameraDirection);

		Vector3 moveDirection = referentialShift * stickDirection;
		Vector3 axisSign = Vector3.Cross (moveDirection, rootDirection);

		float angleRootToMove = Vector3.Angle (rootDirection, moveDirection) * (axisSign.y >= 0 ? -1f : 1f);

		angleRootToMove /= 180f;

		directionOut = angleRootToMove * directionSpeed;


	}

/*	public bool isInLocomotion(){
			return stateInfo.nameHash == m_LocomotionId;
	}*/
	
}

