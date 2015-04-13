using UnityEngine;
using System.Collections;

public class CharacterLoader : MonoBehaviour {
	public Renderer mechanoidSkin;


	// Use this for initialization
	void Start () {
		if(GameControl.control.mechanoidSkin != null){
			mechanoidSkin.material = GameControl.control.mechanoidSkin.GetComponent<Renderer>().material;
		} else{
			Debug.Log("Unable to load character skin");
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
