using UnityEngine;
using System.Collections;

public class CreatureAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;
	public Material chargeMaterial;
	public ParticleSystem PartSys;

	private GameObject player;
	private newPlayerBat playerBattery;
//	private CreatureHealth enemyHealth;
	private bool playerInRange;
	private float timer;
	private bool isSuperCharged = false;

	private Renderer[] childRenderers;
	private NavMeshAgent NavMesh;
	
	
	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerBattery = player.GetComponent <newPlayerBat> ();

		childRenderers = GetComponentsInChildren<Renderer> ();
		NavMesh = GetComponent<NavMeshAgent> ();

//		enemyHealth = GetComponent<CreatureHealth>();
	}
	
	
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = true;
		}
	}
	
	
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = false;
		}
	}
	
	
	void Update ()
	{
		timer += Time.deltaTime;
		
		if(timer >= timeBetweenAttacks && playerInRange) //&& enemyHealth.currentHealth > 0)
		{
			//Attack ();
			StartCoroutine(Attack());
		}
	}
	
	
	IEnumerator Attack ()
	{
		timer = 0f;
		
		if(playerBattery.currentBattery > 0)
		{

			PartSys.Stop ();
			PartSys.Play();

			yield return new WaitForSeconds(.2f);

			playerBattery.TakeDamage (attackDamage);
			if(!isSuperCharged){

				isSuperCharged = true;
				chargeEnemy();

			}
		}
	}

	void chargeEnemy()
	{
		for (int i = 0; i < childRenderers.Length; i++){

			if(childRenderers[i].gameObject.tag != "Particle")
				childRenderers[i].material = chargeMaterial;
		}

		NavMesh.speed = 5;

	}
}
