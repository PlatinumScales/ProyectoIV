using UnityEngine;
using System.Collections;

public class AIEEnemy : MonoBehaviour {


	 
	NavMeshAgent vNav;
	GameObject vLocalPlayer;
	private float vRotationDamping=10;
	private bool IsAttack=false;
	public float distanceFromTarget  = 4.0f;
	public Transform vTarget;
	private Vector3 startPosition;  
	private float wanderSpeed = 3f; //Give it the movement speeds
	private bool vFriendInDanger = false;

	public  float vEnemyLife;
	 

	/*public void RestLife(string pEvemyID,int pDamage){
	 

		vEnemyLife = vEnemyLife - pDamage;
		//Debug.Log("Vida2:" + vEnemyLife + " Damage" +  pDamage);
		if(vEnemyLife==0){
			try{
				 
				 
				Animator animator = GameObject.Find (pEvemyID).GetComponent<Animator> ();
		        animator.SetBool ("Death", true);
			    

			}catch(UnityException ex){
				Debug.Log("ERROR");
				Debug.Log(ex.Message);
			}
		}
		 
	}
	
*/
	
	// Use this for initialization
	void Awake(){
		GameObject.Find (gameObject.name).GetComponent<AudioSource>().Play();
		 vLocalPlayer = GameObject.FindGameObjectWithTag ("Player");
		if (vLocalPlayer != null) {
						vTarget = vLocalPlayer.transform;
		}
						vNav = GetComponent<NavMeshAgent> ();
				
		 
	
	}

	 
	

	void PatrolTerrain (){
		vEnemyLife = (float)GameObject.Find(gameObject.name).GetComponent<EnemyHealth>().currentHealth;
		if (vEnemyLife != 0) {
						//Debug.Log ("Patrol Vida:" + vEnemyLife);
			if(vTarget!=null){
						vNav.SetDestination (vTarget.position);
			}
						vNav.speed = wanderSpeed;
						startPosition = this.transform.position;
						//Start Wandering
						InvokeRepeating ("Wander", 3f, 20f);
				}
	}



	void Wander(){
		//Pick a random location within wander-range of the start position and send the agent there
		Vector3 destination = startPosition + new Vector3(Random.Range (-45, 100),
		                                                  0,
		                                                  Random.Range (-35, 150));
		NewDestination(destination);
	}
	//Creating this as it's own method so we can send it directions other when it's just wandering.
	public void NewDestination(Vector3 targetPoint){
		vEnemyLife = GameObject.Find (gameObject.name).GetComponent<EnemyHealth>().currentHealth;
		if (vEnemyLife != 0) {
						//Sets the agents new target destination to the position passed in
						vNav.SetDestination (targetPoint);
				}
	}



	
	void Start () {
		vEnemyLife = (float)GameObject.Find (gameObject.name).GetComponent<EnemyHealth>().currentHealth;
		          if (vEnemyLife != 0) {
			 
			                PatrolTerrain ();
		            }
		           gameObject.name = gameObject.GetInstanceID().ToString();
	}
	
	void OnTriggerExit(Collider other){

		Debug.Log ("OnTriggerExit");
		IsAttack = false;
		vEnemyLife = GameObject.Find (gameObject.name).GetComponent<EnemyHealth>().currentHealth;
		if (vEnemyLife != 0) {
		Debug.Log(gameObject.name);
		
		//if (gameObject.name.Contains ("EnemySpider")) {
		Animator animator = GameObject.Find (gameObject.name).GetComponent<Animator> ();
						animator.SetBool ("Bite", false);
		//		}
		}
		
	}




	void OnTriggerEnter(Collider other){
		vEnemyLife = GameObject.Find (gameObject.name).GetComponent<EnemyHealth>().currentHealth;
		if(other.gameObject.tag == "Player"){

			if(vEnemyLife!=0){
			IsAttack=true;
		    Attack ();

			int i = 1;
			while (i < 60 && IsAttack )
			{
				Invoke ("ApplyDamage",i);

				i++;
			}

			}	
		}
		 
			
		 

	}

	private void ApplyDamage(){
		vEnemyLife = GameObject.Find (gameObject.name).GetComponent<EnemyHealth>().currentHealth;

		if(vEnemyLife!=0){
			Debug.Log("ataca al juegador");
			vLocalPlayer.GetComponent<Health>().RestLifePlayer(30);

		//TODO PENDIENTE
		Animator animator = vLocalPlayer.GetComponent<Animator> ();

		animator.SetBool ("HitF", true);
		}
			 
    }




	
	// Update is called once per frame
	void Update () {
		vEnemyLife = GameObject.Find (gameObject.name).GetComponent<EnemyHealth>().currentHealth;
		if (vEnemyLife!=0) {
			if(vTarget!=null){
						var dist = Vector3.Distance (vTarget.position, transform.position);
						if (dist < 25f ) {
				               
								LookAtPlayer ();
								
						}
			 
						if(vFriendInDanger)
						{
				      
							LookAtPlayer ();
						}

			}

				}
	

	}

	void LookAtPlayer(){


		Quaternion vRotation = Quaternion.LookRotation(vTarget.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation,vRotation,Time.deltaTime * vRotationDamping);

		vNav.SetDestination (vTarget.position);
		 
	}

	 

	void Attack(){
		vEnemyLife = GameObject.Find (gameObject.name).GetComponent<EnemyHealth>().currentHealth;
		if (vEnemyLife != 0) {


			//if (gameObject.name.Contains ("EnemySpider")) {
			//Debug.Log("ataca");
			//vNav.Stop (true);
			
			Animator animator = GameObject.Find (gameObject.name).GetComponent<Animator> ();
			animator.SetBool ("Bite", true); 
			vFriendInDanger=true;




	    }

	}


}
