using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour{
		public Animator animator;
		public float maxHealth = 100;
		public float maxShield = 100;
		public float currentHealth = 100;
		public float currentShield = 100;
		public float regenDelay = 0;
		public float maxRegenDelay = 5;
		public float regenRate = 20;
		//GameObject vLocalPlayer;

		// Use this for initialization
		void Start ()
		{
				regenDelay = 0;

		}
	
		// Update is called once per frame
	void Update (){
		if (regenDelay < maxRegenDelay) {
			regenDelay += Time.deltaTime;
		} else {
			if (currentShield < maxShield) {
				currentShield += regenRate * Time.deltaTime;
			}
		}
	}

	public void RestLifePlayer (float damage){
		Debug.Log ("APPLY DAMAGE PERSONAJE");
		Debug.Log (damage.ToString());
		//Debug.Log (currentShield.ToString());
		//Debug.Log (currentHealth.ToString());
		regenDelay = 0;
		if (currentShield > 0) {
				currentShield -= damage;
		} else {
				currentShield = 0;
			if (currentHealth > 0) {
				currentHealth -= damage;
			}
		}

		if (currentShield <= 0){
			currentShield = 0;
		}
		if(currentHealth <= 0){
			currentHealth = 0;
			animator.SetBool ("Death2", true);
		}



	}

}
