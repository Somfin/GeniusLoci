using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartButtonScript : MonoBehaviour {

	public Image smallImage;
	public Image largeImage;

	//private Rect startRect;
	//private RectTransform startRectTransform;

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void makeSmall(){

		largeImage.enabled = false;
		smallImage.enabled = true;

	}

	public void makeBig(){

		smallImage.enabled = false;
		largeImage.enabled = true;

	}

	void OnSelect()
	{
		Debug.Log ("SLECTED");
	}
}
/*	void OnMouseEnter(){

		Debug.Log ("Mouse Enter");

		smallImage.enabled = false;
		largeImage.enabled = true;

		startRectTransform = startImage.rectTransform;
		startRect.height = 75;
		startRect.width = 200;
		startRectTransform.rect = startRect;

		startImage.rectTransform = startRectTransform;
		//startImage.rectTransform.rect.height = 75;
		//startImage.rectTransform.rect.width = 200;


	}

	void OnMouseExit(){

		largeImage.enabled = false;
		smallImage.enabled = true;

		startRect.height = 50;
		startRect.width = 125;
		startImage.rectTransform.rect = startRect;

		//startImage.rectTransform.rect.height = 50;
		//startImage.rectTransform.rect.width = 125;
	}

}*/
