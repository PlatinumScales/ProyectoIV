using UnityEngine;
using System.Collections;

public class MissionW : MonoBehaviour {

	public Animator guiAnimator;

	public GameObject[] objectives;

	private float check = 5f;
	private float checkDelay = 0f;
	public bool completed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (checkDelay > check) {
			bool objCheck = true;
			for(int i = 0; i < objectives.Length; i++){
				if(objectives[i] != null){
					objCheck = false;
					Debug.Log("HI");
				}
			}
			if(objCheck){
				guiAnimator.SetTrigger("FadeIn");
				Debug.Log("Mission completed");
			}
			checkDelay -= check;
		}

		checkDelay += Time.deltaTime;
	}
}
