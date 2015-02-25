using UnityEngine;
using System.Collections;

public class PlanetaryRotation : MonoBehaviour {

	public float speed = 1;
	
	
	void Update ()
	{
		transform.Rotate(Vector3.up, speed * Time.deltaTime);
	}
}
