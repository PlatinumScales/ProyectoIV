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
	public bool targettt=false;
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
		if(targettt==false){
			Debug.LogWarning("Finding");
			vLocalPlayer = GameObject.FindGameObjectWithTag ("Player");
			if (vLocalPlayer != null) {
				Debug.LogWarning("Finding true");
				vTarget = vLocalPlayer.transform;
				targettt=true;
			}
		}
			
			Quaternion vRotation = Quaternion.LookRotation(vTarget.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation,vRotation,Time.deltaTime * vRotationDamping);
			
			vNav.SetDestination (vTarget.position);
			
		 


		Debug.Log("Baja energia al enemigo");
		Debug.Log("EnemyLife:" + currentHealth + "Damage" +  damage);
		GameObject.Find("HITMESSAGE").GetComponent<HITMESSAGESCRIPT>().ShowMessage("HIT ENEMY HEALTH:" + currentHealth + "/DAMAGE:" + damage.ToString(),Color.white);

		//if (currentShield > 0) {
		//	currentShield -= damage;
		//} else {
			if (currentHealth > 0) {

			//GetComponent<DamageMultiplierEffect>().DamageEffect();
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
			Invoke ("DeleteEnemy",3f);
			GameObject.Find("HITMESSAGE").GetComponent<HITMESSAGESCRIPT>().ShowMessage("KILLED",Color.red);
			 
			
		}
		
		
	}

	private void DeleteEnemy(){

		Destroy (gameObject);
	}
}