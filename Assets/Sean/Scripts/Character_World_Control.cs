using UnityEngine;
using System.Collections;

public class Character_World_Control : MonoBehaviour {

	public GUIText doorLocked;
	private bool hasKey;
	public float pushPower = 2f;

	void Start(){
		hasKey = false;
		doorLocked.text = "";
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		
		Collider other = hit.collider;
		if (other.gameObject.tag == "Movable") {
			Vector3 pushDir = new Vector3 (hit.moveDirection.x, 0, hit.moveDirection.z);
			hit.collider.attachedRigidbody.velocity = pushDir * pushPower;
		}
		
		if (other.gameObject.tag == "Door") {
			if(!hasKey){
				doorLocked.text = "DOOR NEEDS KEY";
				Invoke ("EraseText", 3);
			}else{
				other.gameObject.SetActive(false);
				doorLocked.text = "YOU WIN!";
			}
		}
	}
	
	void EraseText(){
		doorLocked.text = "";
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Key") {
			other.gameObject.SetActive(false);
			hasKey = true;
		}
	}
}
