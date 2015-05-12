using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BatteryManager : MonoBehaviour {
		
	public float lowBatteryPercent = 20; //What percentage counts as low battery
	public CanvasGroup battery;
	public Image bar;
	public Text text;

	private float batteryPercentage = 100f; //Will be removed after implementation of game

	public PlayerBattery playerBattery; //Add player battery script here

	private float currentBattery;
	private float maxBattery;

	//for fade
	public float fadeTime = 1f;

	private bool fadeOut = true;
	private bool isRed = false;


	void Start(){

		//UpdateHealth (19); //Will be removed upon implementation;
		maxBattery = playerBattery.maxBattery;

	}

	// Update is called once per frame
	void Update () {

		currentBattery = playerBattery.currentBattery;     //Comment these in at implemenetation
		//maxBattery = playerBatter.maxBattery;

		batteryPercentage = (currentBattery/maxBattery) * 100;
		bar.fillAmount = batteryPercentage / 100;

		if(batteryPercentage < 0)
			text.text = 0 + "%";
		else
			text.text = (int)batteryPercentage + "%";

		if(batteryPercentage <= lowBatteryPercent){

			if (!isRed)
				makeRed ();

			if (fadeOut) {
				battery.alpha -= Time.deltaTime / fadeTime;
				if (battery.alpha <= 0)
					fadeOut = false;
			
			} else {
				battery.alpha += Time.deltaTime / fadeTime;
				if (battery.alpha >= 1)
					fadeOut = true;
			}

		} else {
			battery.alpha = 1;
			if (isRed)
				makeBlack ();

		}
	}

	public void UpdateHealth(float health){ //Will be removed after implementation in game

		batteryPercentage = health;

		bar.fillAmount = health / 100f;

	}

	void makeRed(){
		bar.color = Color.red;
		isRed = true;
	}

	void makeBlack(){
		bar.color = Color.black;
		isRed = false;
	}

}
