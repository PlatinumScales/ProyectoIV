using UnityEngine;
using System.Collections;

public class DelayScript : MonoBehaviour {
	public float delayTime = 5;
	public int nextlevel = 1;
	IEnumerator Start(){
		yield return new WaitForSeconds (delayTime);
		AutoFade.LoadLevel (nextlevel ,1,1,Color.black);
	}
}
