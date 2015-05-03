using UnityEngine;
using System.Collections;

public class Camera_Controller : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;
	
	// Use this for initialization
	void Start () {
		
		offset = transform.position-player.transform.position;
		
	}
	
	// Update is called once per frame
	void LateUpdate () {

		Vector3 cameraPos = transform.position;
		Vector3 playerPos = player.transform.position;
		
		cameraPos.x = playerPos.x + offset.x;
		transform.position = cameraPos;

		transform.LookAt (player.transform);
	}
}
