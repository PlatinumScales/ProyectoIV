using UnityEngine;
using System.Collections;

public class HealthPlayerScript : MonoBehaviour {
	
	public float vHealth=100;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(vHealth < 0f){
			//TODO PROGRAMAR QUE HACER CUANDO MUERA EL PERSONAJE
			//Destroy(gameObject);
		}
		
	}
}
