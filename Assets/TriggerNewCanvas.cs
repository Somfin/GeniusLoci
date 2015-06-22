using UnityEngine;
using System.Collections;

public class TriggerNewCanvas : TriggerBase {
	public GameObject newCanvas;
	public float rate;
	public bool active;
	
	// Use this for initialization
	void Start () {
		newCanvas.GetComponent<CanvasGroup> ().alpha = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (active && newCanvas.GetComponent<CanvasGroup>().alpha < 0.99){
			newCanvas.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(newCanvas.GetComponent<CanvasGroup>().alpha, 1f, rate);
			GetComponent<CanvasGroup>().alpha = Mathf.Lerp(GetComponent<CanvasGroup>().alpha, 0f, rate);
		} else if (active) {
			newCanvas.GetComponent<CanvasGroup>().alpha = 1;
			gameObject.SetActive (false);
			active = false;
		}
	}

	public override void Activate() {
		active = true;
		newCanvas.SetActive (true);
	}
}
