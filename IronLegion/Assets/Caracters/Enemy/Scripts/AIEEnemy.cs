﻿using UnityEngine;
using System.Collections;

public class AIEEnemy : MonoBehaviour {


	 
	NavMeshAgent vNav;
	GameObject vLocalPlayer;
	private float vRotationDamping=10;
	private bool IsAttack=false;
	public float distanceFromTarget  = 4.0f;
	public Transform vTarget;
	private Vector3 startPosition;  
	private float wanderSpeed = 5f; //Give it the movement speeds

	private  int vEnemyLife=30;
	 

	public void RestLife(string pEvemyID,int pDamage){
	 

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
	

	
	// Use this for initialization
	void Awake(){
		GameObject.Find (gameObject.name).GetComponent<AudioSource>().Play();
		 vLocalPlayer = GameObject.FindGameObjectWithTag ("Player");
		vTarget = vLocalPlayer.transform;
		vNav = GetComponent<NavMeshAgent>();
		 
	
	}

	 
	

	void PatrolTerrain (){
		if (vEnemyLife != 0) {
						//Debug.Log ("Patrol Vida:" + vEnemyLife);
						vNav.SetDestination (vTarget.position);
						vNav.speed = wanderSpeed;
						startPosition = this.transform.position;
						//Start Wandering
						InvokeRepeating ("Wander", 2f, 20f);
				}
	}



	void Wander(){
		//Pick a random location within wander-range of the start position and send the agent there
		Vector3 destination = startPosition + new Vector3(Random.Range (-50, 100),
		                                                  0,
		                                                  Random.Range (-50, 150));
		NewDestination(destination);
	}
	//Creating this as it's own method so we can send it directions other when it's just wandering.
	public void NewDestination(Vector3 targetPoint){
		if (vEnemyLife != 0) {
						//Sets the agents new target destination to the position passed in
						vNav.SetDestination (targetPoint);
				}
	}



	
	void Start () {
		//Debug.Log ("Inicio vida:" + vEnemyLife);
		          if (vEnemyLife != 0) {
			//Debug.Log("Patroling..." + vEnemyLife);
			PatrolTerrain ();
		}
		gameObject.name = gameObject.GetInstanceID().ToString();
	}
	
	void OnTriggerExit(Collider other){

		Debug.Log ("OnTriggerExit");
		IsAttack = false;
		//Debug.Log("Patroling..." + vEnemyLife);
		if (vEnemyLife != 0) {
		Debug.Log(gameObject.name);
		
		//if (gameObject.name.Contains ("EnemySpider")) {
		Animator animator = GameObject.Find (gameObject.name).GetComponent<Animator> ();
						animator.SetBool ("Bite", false);
		//		}
		}
		
	}




	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
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

	private void ApplyDamage(){

		vLocalPlayer.GetComponent<Health>().ApplyDamage(2);

		//TODO PENDIENTE
		//Animator animator = vLocalPlayer.GetComponent<Animator> ();

		//animator.SetBool ("HitF", true);
		 
			 
    }




	
	// Update is called once per frame
	void Update () {
		 
		if (vEnemyLife!=0) {
						var dist = Vector3.Distance (vTarget.position, transform.position);
						if (dist < 25f) {

								LookAtPlayer ();
								vNav.SetDestination (vTarget.position);
				               
						}
				}
	

	}

	void LookAtPlayer(){

		Quaternion vRotation = Quaternion.LookRotation(vTarget.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation,vRotation,Time.deltaTime * vRotationDamping);
		 
	}

	 

	void Attack(){
		//Debug.Log ("OnTriggerEnter");
		if (vEnemyLife != 0) {


			//if (gameObject.name.Contains ("EnemySpider")) {
			//Debug.Log("ataca");
			vNav.Stop (true);
			
			Animator animator = GameObject.Find (gameObject.name).GetComponent<Animator> ();
			animator.SetBool ("Bite", true); 




	    }

	}


}
