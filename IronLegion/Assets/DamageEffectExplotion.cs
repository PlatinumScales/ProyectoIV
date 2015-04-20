using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageEffectExplotion : MonoBehaviour {

	public float explosionForce = 4;
	
	
	 

	public IEnumerator DamageEffect(){
		// wait one frame because some explosions instantiate debris which should then
		// be pushed by physics force
		yield return null;
		
		float multiplier = GetComponent<DamageMultiplierEffect>().multiplier;
		
		float r = 10*multiplier;
		var cols = Physics.OverlapSphere(transform.position, r);
		var rigidbodies = new List<Rigidbody>();
		foreach (var col in cols)
		{
			if (col.attachedRigidbody != null && !rigidbodies.Contains(col.attachedRigidbody))
			{
				rigidbodies.Add(col.attachedRigidbody);
			}
		}
		foreach (var rb in rigidbodies)
		{
			rb.AddExplosionForce(explosionForce*multiplier, transform.position, r, 1*multiplier, ForceMode.Impulse);
		}

	}

}
