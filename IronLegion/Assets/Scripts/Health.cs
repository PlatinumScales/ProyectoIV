using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{

		public float maxHealth = 100;
		public float maxShield = 100;
		public float currentHealth = 100;
		public float currentShield = 100;
		public float regenDelay = 0;
		public float maxRegenDelay = 5;
		public float regenRate = 20;

		// Use this for initialization
		void Start ()
		{
				regenDelay = 0;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (regenDelay < maxRegenDelay) {
						regenDelay += Time.deltaTime;
				} else {
						if (currentShield < maxShield) {
								currentShield += regenRate * Time.deltaTime;
						}
				}
	
		}

		public void ApplyDamage (float damage)
		{
				if (currentShield > 0) {
						currentShield -= damage;
				} else {
						if (currentHealth > 0) {
								currentHealth -= damage;
						}
					
		
				}
		regenDelay = 0;
		}
}
