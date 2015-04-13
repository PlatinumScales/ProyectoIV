using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class LoadGameScreen : MonoBehaviour {
	public List<PlayerData> pdl = new List<PlayerData>();
	public RectTransform loadPanel;
	public List<string> missions;

	// Use this for initialization
	void Start () {
		PlayerDataManager.pdm.playerNames.ForEach(delegate(string name){
			pdl.Add(PlayerDataManager.pdm.Load(name));
		});
		float x = 0f;
		float y = 0f;
		missions = new List<string>{"ENCAMPMENT", "WASTELAND", "RAGNAROK"};	

		bool flag = true;
		int index = 0;
		foreach(PlayerData pd in pdl){
			RectTransform g =  Instantiate (loadPanel) as RectTransform; 
			g.name = " loadPanel" + index;
			g.SetParent(transform,false);
			g.localScale = new Vector3(1f,1f);
			if(flag){
				y-= 130f;
				x = 0f;
			}else{
				x = 650f;
			}
			flag = !flag;
			g.localPosition = new Vector2(x,y);
			
			Transform[] children = g.GetComponentsInChildren<Transform>();
			foreach(Transform t in children){
				switch (t.name)
				{
				case "PlayerName":
					t.GetComponent<Text>().text = pd.playerName;
					break;
				case "LastSave":
					t.GetComponent<Text>().text = "";
					break;
				case "Mission":
					Debug.Log(pd.mission);
					t.GetComponent<Text>().text =""  + missions[pd.mission];
					break;
				default:
					break;
				}
			}

		}

	}

	// Update is called once per frame
	void Update () {
	
	}
}
