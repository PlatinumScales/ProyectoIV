using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {
	public static GameControl control;
	public PlayerData playerData;
	public GameObject mechanoidSkin;
	
	// Use this for initialization
	void Awake () {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		}else if(control != this) {
			Destroy(gameObject); 
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Save(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create(Application.persistentDataPath + "/" + playerData.playerName + ".dat");	
		bf.Serialize (file, playerData);
		file.Close ();
	}

}










