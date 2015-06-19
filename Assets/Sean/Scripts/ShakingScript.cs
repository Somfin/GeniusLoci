using UnityEngine;
using System.Collections;

public class ShakingScript : MonoBehaviour {
	

	// How long the object should shake for.
	public float shakeTime = 1.5f;
	//public float timeDecreaseFactor = 1.0f;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.1f;
	// This can dictate if shake speeds or slows. Positive numbers mean shake speeds
	public float shakeAmountChangeFactor;

	public float whenToStartShake = 0f; //This is a decimal representing at what point in motion the object shakes

	public bool shakesCamera = false;
	public float whenToShakeCamera = .8f;
	//public float cameraShakeTime = 1f;
	public float cameraShakeAmount = 1f;
	private bool cameraTriggered = false;


	private TriggerShift heightScript;
	private CameraShake camScript;


	void OnEnable()
	{
		//originalPos = objectTransform.localPosition;

		heightScript = GetComponent<TriggerShift> ();
		camScript = Camera.main.GetComponent<CameraShake> ();
	}

	void LateUpdate()
	{
		if(heightScript.moving && (heightScript.percentCovered > whenToStartShake)){

			if (shakeTime > 0){
				transform.position = transform.position + Random.insideUnitSphere * shakeAmount;
			
				shakeTime -= Time.deltaTime;
				shakeAmount += Time.deltaTime * shakeAmountChangeFactor;
			}
			else {
				shakeTime = 0f;
			}
		}
		if (heightScript.moving) {
			if (shakesCamera)
				ShakeCamera ();
		}
	}

	void ShakeCamera(){

		if (!cameraTriggered) {

			if (heightScript.percentCovered > whenToShakeCamera) {

				//camScript.shake = cameraShakeTime;
				camScript.shakeAmount += cameraShakeAmount;

				cameraTriggered = true;
			}
		}
	}
}
