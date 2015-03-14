using UnityEngine;
using System.Collections;

public class FootSteps : MonoBehaviour {
	

	public AudioClip stepSound;
	public AudioClip jumpSound;

	private AudioSource source;
	private float volLowRange = .5f;
	private float volHighRange = 1.5f;
	
	// Use this for initialization
	void Awake	 () {
		
		source = GetComponent <AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Walk")) 
		{
			source.loop = true;
			float vol = Random.Range (volLowRange, volHighRange);
			source.PlayOneShot(stepSound, vol);

			
		}
		if (Input.GetButtonDown("Jump"))
		{
			float vol = Random.Range (volLowRange, volHighRange);
			source.PlayOneShot(jumpSound, vol);
		}
	}
}