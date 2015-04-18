using UnityEngine;
using System.Collections;

public class DelayScript : MonoBehaviour {
	public float delayTime = 4;
	public string nextScene ;
	 
	IEnumerator Start(){
		yield return new WaitForSeconds (delayTime);
		AutoFade.LoadLevel ( nextScene ,1,2,Color.black);
	}
}
