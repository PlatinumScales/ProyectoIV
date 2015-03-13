using UnityEngine;
using System.Collections;

public class ItemHealthScript : MonoBehaviour {
	public float GasCount  = 30;

	// Use this for initialization
	void Start () {
	
		gameObject.name = gameObject.GetInstanceID().ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider other){
				if (other.gameObject.tag == "Player") {

						float vLife = (float)other.GetComponent<Health> ().currentHealth;

						if (vLife != 100) {
							float sumlife=vLife + GasCount;
							if(sumlife>100){
											other.GetComponent<Health> ().currentHealth = 100;
							}else{
								other.GetComponent<Health> ().currentHealth = sumlife;
							}

				Destroy (gameObject);
						}
			

				}
		}
}
