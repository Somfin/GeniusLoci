using UnityEngine;
using System.Collections;

public class NewEnemyManager : MonoBehaviour {

	public GameObject player;
	public PlayerHealth playerHealth2;
	public GameObject enemy2;
	public float spawnTime2 = 3f;
	public Transform[] spawnPoints2;
	public Collider[] triggerPoints;
	

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.F)) {
			
			Spawn ();
		}
	}
	
	
	void Spawn (){


		if(playerHealth2.currentHealth <= 0f)
		{
			return;
		}
		
		int spawnPointIndex = Random.Range (0, spawnPoints2.Length);
		
		Instantiate (enemy2, spawnPoints2[spawnPointIndex].position, spawnPoints2[spawnPointIndex].rotation);
	}
}
