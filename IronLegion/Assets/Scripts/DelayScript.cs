using UnityEngine;
using System.Collections;

public class DelayScript : MonoBehaviour {
	public float delayTime = 4;
	 
	IEnumerator Start(){
		yield return new WaitForSeconds (delayTime);
		AutoFade.LoadLevel ("menuUI" ,1,2,Color.gray);
	}
}
