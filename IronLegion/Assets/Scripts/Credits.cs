using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	public GameObject creditCam;
	public int speed = 1;
	public string level;

	// Update is called once per frame
	void Update () {
		creditCam.transform.Translate (Vector3.down * Time.deltaTime * speed);

	}

	IEnumerator waitFor(){

		yield return new WaitForSeconds (90);
		AutoFade.LoadLevel ("LightHouseSplash" ,1,2,Color.gray);
		//Application.LoadLevel (level);
		//AutoFade.LoadLevel ("LightHouseSplash" ,1,2,Color.gray);

	}
}
