using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public Animator animator;
	public float maxHealth = 100;
	public float maxShield = 100;
	public float currentHealth = 300;
	//public float currentShield = 100;
	public float regenDelay = 0;
	public float maxRegenDelay = 5;
	public float regenRate = 20;
	//GameObject vLocalPlayer;
	private float vRotationDamping=10;
	public float distanceFromTarget  = 4.0f;
	public Transform vTarget;
	NavMeshAgent vNav;
	GameObject vLocalPlayer;
	// Use this for initialization
	void Start ()
	{
		vLocalPlayer = GameObject.FindGameObjectWithTag ("Player");
		if (vLocalPlayer != null) {
			vTarget = vLocalPlayer.transform;
		}
		vNav = GetComponent<NavMeshAgent> ();
		regenDelay = 0;
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		 
		
	}
	
	public void RestEnemyLife (float damage)
	{
		Debug.Log(damage);

			
			Quaternion vRotation = Quaternion.LookRotation(vTarget.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation,vRotation,Time.deltaTime * vRotationDamping);
			
			vNav.SetDestination (vTarget.position);
			
		 


		Debug.Log("Baja energia al enemigo");
		//if (currentShield > 0) {
		//	currentShield -= damage;
		//} else {
			if (currentHealth > 0) {
				currentHealth -= damage;
			}
			
			
		//}


		if (currentHealth<=0) {
			try{

				
				Animator animator = GameObject.Find (gameObject.name).GetComponent<Animator> ();
				animator.SetBool ("Death", true);
				
				
			}catch(UnityException ex){
				Debug.Log("ERROR");
				Debug.Log(ex.Message);
			}
			Invoke ("DeleteEnemy",4f);
			 
			
		}
		
		
	}

	private void DeleteEnemy(){

		Destroy (gameObject);
	}
}