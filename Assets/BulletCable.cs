using UnityEngine;
using System.Collections;

public class BulletCable : MonoBehaviour {
	private LineRenderer cable;
	private GameObject origin;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		cable.SetVertexCount (2);
		cable.SetPosition (0, origin.transform.position);
		cable.SetPosition (1, gameObject.transform.position);
	}
	
	public void setOrigin(GameObject origin){
		this.origin = origin;
	}

	public void setCable(LineRenderer cable){
		this.cable = cable;
		cable.enabled = true;
	}

	public void kill(){
		cable.SetVertexCount (0);
		this.enabled = false;
	}
}
