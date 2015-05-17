using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Crosshair : MonoBehaviour {

	public float maxDistance = 50f;
	public Image crosshairImage;
	public float maxCrosshairLength = 40f; //Crosshair size at its largest
	public float minCrosshairLength = 20f; //Crosshair size at its smallest

	private float range;
	private RaycastHit hit;
	private Vector3 viewportPoint;

	void Start()
	{
		//Rect r = crosshairImage.rectTransform.rect;
		range = maxCrosshairLength - minCrosshairLength;

		crosshairImage.rectTransform.sizeDelta = new Vector2 (maxCrosshairLength, maxCrosshairLength);

	/*	r.width = maxCrosshairLength;
		r.height = maxCrosshairLength;
		crosshairImage.rectTransform.rect = r;*/

	}

	// Update is called once per frame
	void Update () {
	
		Vector3 tempVec = transform.forward * 20;
		tempVec.y += .8f;

		Debug.DrawRay(transform.position, tempVec, Color.blue);

		if (Physics.Raycast (transform.position, tempVec, out hit, maxDistance)) {

			viewportPoint = Camera.main.WorldToViewportPoint (hit.point);

			//Debug.Log("viewportPoint " + viewportPoint);

			crosshairImage.rectTransform.anchorMax = new Vector2(viewportPoint.x, viewportPoint.y);
			crosshairImage.rectTransform.anchorMin = new Vector2(viewportPoint.x, viewportPoint.y);

			resize();

			crosshairImage.gameObject.SetActive (true);
		} else 
			crosshairImage.gameObject.SetActive (false);
	}

	void resize()
	{
		//Rect r = crosshairImage.rectTransform.rect;
		float length = maxCrosshairLength - (range * (hit.distance/maxDistance));

		crosshairImage.rectTransform.sizeDelta = new Vector2 (length, length);
		/*r.width = length;
		r.height = length;
		crosshairImage.rectTransform.rect = r;*/
		// crosshairImage.rectTransform.rect.height);
		
	}
}
