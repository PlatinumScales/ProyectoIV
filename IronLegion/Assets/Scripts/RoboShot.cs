using UnityEngine;
using System.Collections;

public class RoboShot : MonoBehaviour {

	public AudioClip shootSound;

	private AudioSource source;
	private float volLowRange = .5f;
	private float volHighRange = 1.5f;
	
	// Use this for initialization
	void Awake	 () {
		
		source = GetComponent <AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) 
		{
			float vol = Random.Range (volLowRange, volHighRange);
			source.PlayOneShot(shootSound, vol);

			
		}
	}
}

