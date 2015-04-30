using UnityEngine;
using System.Collections;

public class CreatureHealth : MonoBehaviour {
	public int maxHealth;

	private int currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void takeDamage (int damage) {
		currentHealth -= damage;
		if (currentHealth <= 0) {
			GameObject.Destroy (gameObject);
		}
	}

	void OnGui(){

	}
}
