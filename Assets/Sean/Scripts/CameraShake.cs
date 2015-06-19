using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	private Transform camTransform;
	
	// How long the object should shake for.
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.7f;
	public float shakeAmountDampening = 0.2f;
	//public float decreaseFactor = 1.0f;
	
	Vector3 originalPos;
	
	void Awake()
	{
			camTransform = Camera.main.transform;
	}
	
	/*void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}*/

	void Update()
	{
		camTransform.localPosition = camTransform.localPosition + Random.insideUnitSphere * shakeAmount;
	}
	
	void FixedUpdate()
	{
		shakeAmount = Mathf.Lerp(shakeAmount, 0, shakeAmountDampening);
	}
}
