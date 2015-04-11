using UnityEngine;
using System.Collections;

public class FootSteps : MonoBehaviour {
	

	public AudioClip stepSound;
	public AudioClip jumpSound;

	private AudioSource source;
	private float volLowRange = .3f;
	private float volHighRange = 4f;
	
	// Use this for initialization
	void Awake	 () {
		
		source = GetComponent <AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		bool vSound = true;
		if (Input.GetButtonDown("Vertical")) 
		{
			 
			float vol = Random.Range (volLowRange, volHighRange);
    		source.PlayOneShot(stepSound, vol);
				 
			 
		}

		
		/*if (Input.GetButtonDown("Jump"))
		{
			float vol = Random.Range (volLowRange, volHighRange);
			source.PlayOneShot(jumpSound, vol);
		}*/
	}
}