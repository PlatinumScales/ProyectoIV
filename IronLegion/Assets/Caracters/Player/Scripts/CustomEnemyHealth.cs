using UnityEngine;
using System.Collections;



public class CustomEnemyHealth : MonoBehaviour {
	public float hp= 50f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (hp <= 0f) {
			Destroy (gameObject);
		}
	
	}

	public void ApplyDamage(float damage){
			hp -= damage;
	}
}
