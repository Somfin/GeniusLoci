using UnityEngine;
using System.Collections;

public class PlayerBattery : MonoBehaviour {

	public PlayerMover playerMover;
	public float maxBattery = 100f;
	public float currentBattery;
	public float batteryDrainSpeed;
	public float batteryRechargeSpeed;
	public float percentCanJumpWithoutBattery = 20f;

	private bool isHoldingJump;
	private float maxJump;
	private float curJump;
	private ParticleSystem partSys;
	private bool isCharging = false;

	// Use this for initialization
	void Start () {
	
		currentBattery = maxBattery;
		maxJump = playerMover.jumpRate;

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

		isHoldingJump = playerMover.jumpHold;
		curJump = playerMover.currentJump;

		if (isHoldingJump && currentBattery > 0) {

			currentBattery -= (Time.deltaTime * batteryDrainSpeed);

			if(currentBattery < 0) //To make sure battery never drops into negatives
				currentBattery = 0f;

		} else if (isHoldingJump && currentBattery <= 0) {

			if(100-((curJump/maxJump)*100) > percentCanJumpWithoutBattery){  //Stops jump after percentage of jump given
				playerMover.jumpHold = false;
			}
		}
	}	

	public void charge(GameObject particles){

		partSys = particles.GetComponent<ParticleSystem> ();

		if (currentBattery < maxBattery) {
			partSys.Pause ();
			isCharging = true;
		} else
			partSys.Clear ();

	}

	public void TakeDamage(int attackDamage)
	{
		currentBattery -= attackDamage;

		if (currentBattery < 0)
			currentBattery = 0;
	}
}
