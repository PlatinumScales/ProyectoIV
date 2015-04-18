using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerDataManager : MonoBehaviour {
	public static PlayerDataManager pdm;
	public List<string> playerNames = new List<string>();
	public List<string> purchases = new List<string>();


	void Awake () {

		if (pdm == null) {
			pdm = this;
		}else if(pdm != this) {
			Destroy(gameObject); 
		}
		if(File.Exists(Application.persistentDataPath + "/playerNames"  + ".gd")){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath +"/playerNames"  + ".gd", FileMode.Open);
			playerNames = (List<string>)bf.Deserialize(file);
			file.Close();
		}
		if(File.Exists(Application.persistentDataPath + "/purchases"  + ".gd")){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath +"/purchases"  + ".gd", FileMode.Open);
			purchases = (List<string>)bf.Deserialize(file);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void Save(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create(Application.persistentDataPath + "/playerNames" + ".gd");	
		bf.Serialize (file, playerNames);
		file.Close ();
	}

	public void SavePurchases(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create(Application.persistentDataPath + "/purchases" + ".gd");	
		bf.Serialize (file, purchases);
		file.Close ();
	}

	public PlayerData Load(string name){
		PlayerData pd = null;
		if(File.Exists(Application.persistentDataPath + "/" + name + ".dat")){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath +"/" + name + ".dat", FileMode.Open);
			pd = (PlayerData)bf.Deserialize(file);
			file.Close();
		}
		return pd;
	}
}
