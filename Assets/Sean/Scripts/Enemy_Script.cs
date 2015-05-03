using UnityEngine;
using System.Collections;

public class Enemy_Script : MonoBehaviour {

	public float gravity = 20.0f;
	public float pathEndThreshold = 0.1f;
	private bool hasPath = false;
	public float patrolSpeed = 2f;
	//public Vector3[] patrolWaypoints;
	public Transform[] patrolWaypoints;

	private int wayPointIndex;
	private NavMeshAgent nav;
	private Collider col;

	private int patrolPos;
	private CharacterController CharControl;
	private Vector3 moveDirection;
	private bool isStopped;

	Animator anim;
	//1 if moving, 0 if not
	float isMoving = 0f;

	void Start() {
		isStopped = false;

		anim = GetComponent<Animator> ();

		nav = GetComponent<NavMeshAgent> ();
		col = GetComponent<MeshCollider> ();

		CharControl = GetComponent<CharacterController>();

		wayPointIndex = 0;
		patrolPos = 0;

	}

	void Update() {

		if (isStopped)
			stopped ();
		else
			Patrolling ();

		/*if (nav.velocity == Vector3.zero)
			isMoving = 0f;
		else
			isMoving = 1f;*/
	}
	void Patrolling(){

		//Move along top to right

		anim.SetFloat("isMoving", 1);
		if (patrolPos == 0) {
			moveDirection = new Vector3 (0, 0, 1);
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= patrolSpeed;

			moveDirection.y -= gravity * Time.deltaTime;
			CharControl.Move (moveDirection * Time.deltaTime);

			if (transform.position.z <= -8f){
				transform.Rotate(new Vector3(0, 90, 0));
				patrolPos = 1;
			}

			//Move along right to bottom
		} else if (patrolPos == 1) {
			moveDirection = new Vector3 (0, 0, 1);
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= patrolSpeed;
				
			moveDirection.y -= gravity * Time.deltaTime;
			CharControl.Move (moveDirection * Time.deltaTime);
				
			if (transform.position.x <= -6f){
				patrolPos = 2;
				transform.Rotate(new Vector3(0, 90, 0));
			}
		
		//Move along bottom to left
		}else if (patrolPos == 2) {
			moveDirection = new Vector3 (0, 0, 1);
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= patrolSpeed;
			
			moveDirection.y -= gravity * Time.deltaTime;
			CharControl.Move (moveDirection * Time.deltaTime);
			
			if (transform.position.z >= 8f){
				patrolPos = 3;
				transform.Rotate(new Vector3(0, 90, 0));
			}
		
		//Move along left to top
		}else{
			moveDirection = new Vector3 (0, 0, 1);
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= patrolSpeed;
			
			moveDirection.y -= gravity * Time.deltaTime;
			CharControl.Move (moveDirection * Time.deltaTime);
			
			if (transform.position.x >= -2f){
				patrolPos = 0;
				transform.Rotate(new Vector3(0, 90, 0));
			}
		}
		
		
	}

	void stopped(){
		anim.SetFloat("isMoving", 0);

		Invoke ("switchIsStopped", 3);
	}

	void switchIsStopped(){
		isStopped = false;
	}



	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.gameObject.tag == "Player" || hit.gameObject.tag == "Movable")
			isStopped = true;
	}
}
