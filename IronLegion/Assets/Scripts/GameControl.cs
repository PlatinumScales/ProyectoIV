using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

	public static GameControl control;
	public PlayerData playerData;

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
		/*PlayerData data = new PlayerData ();
		data.playerName = playerData.playerName;
		 */
		bf.Serialize (file, playerData);
		file.Close ();
	}

	public void Load(){
		if(File.Exists(Application.persistentDataPath + "/" + playerData.playerName + ".dat")){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath +"/" + playerData.playerName + ".dat", FileMode.Open);
			playerData = (PlayerData)bf.Deserialize(file);
			file.Close();
		}

	}
}









