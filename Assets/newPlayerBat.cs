using UnityEngine;
using System.Collections;

public class newPlayerBat : MonoBehaviour {
	
	public float maxBattery = 100f;
	public float currentBattery;
	//public ParticleSystem partSys;

	public float batteryRechargeSpeed;
	
	private bool isCharging = false;
	
	// Use this for initialization
	void Start () {
		
		currentBattery = maxBattery;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (isCharging && currentBattery >= maxBattery) {
			isCharging = false;
		}
		if (isCharging) {
			currentBattery += (Time.deltaTime * batteryRechargeSpeed);
			if(currentBattery > maxBattery)
				currentBattery = maxBattery;
		}
	}	
	
	public void charge(GameObject particles){
		
		//partSys = particles.GetComponent<ParticleSystem> ();
		
		if (currentBattery < maxBattery) {
			//partSys.Pause ();
			isCharging = true;
		} //else
			//partSys.Clear ();
		
	}
	
	public void TakeDamage(int attackDamage)
	{
		currentBattery -= attackDamage;
		
		if (currentBattery < 0)
			currentBattery = 0;
	}
}
