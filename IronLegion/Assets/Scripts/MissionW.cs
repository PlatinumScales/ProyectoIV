using UnityEngine;
using System.Collections;

public class MissionW : MonoBehaviour {

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
			for(int i = 0; i < objectives.Length; i++)
			{
				bool objCheck = true;
				if(objectives[i] != null){
					objCheck = false;
				}
				if(objCheck){
					Debug.Log("Mission completed");
				}
			}

			checkDelay += check;
		}

		checkDelay += Time.deltaTime;
	}
}
