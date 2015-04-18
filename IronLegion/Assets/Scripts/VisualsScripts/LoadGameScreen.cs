using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class LoadGameScreen : MonoBehaviour {
	//public List<PlayerData> pdl = new List<PlayerData>();
	public RectTransform loadPanel;
	public List<string> missions;
	public List<GameObject> mechanoidSkins;

	// Change panel name to i then onclic(Gamecontroler.Playerdata = pdl[i])

	// Use this for initialization
	void Start () {
		Vector2 wh = gameObject.GetComponent<RectTransform>().sizeDelta;
		gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(wh.x, ((PlayerDataManager.pdm.playerNames.Count/4))*140f);
		
		float x = 0f;
		float y = 0f;
		bool flag = true;
		int index = 0;

		foreach(string name in PlayerDataManager.pdm.playerNames){
			PlayerData pd = PlayerDataManager.pdm.Load(name);
			RectTransform g =  Instantiate (loadPanel) as RectTransform; 
			g.name = ""+ index;
			g.SetParent(transform,false);
			g.localScale = new Vector3(1f,1f);
			if(flag){
				y-= 140f;
				x = 0f;
			}else{
				x = 550f;
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
					t.GetComponent<Text>().text = pd.date;
					break;
				case "Mission":
					Debug.Log(pd.mission);
					t.GetComponent<Text>().text =""  + missions[pd.mission];
					break;
				default:
					break;
				}
			}
			g.GetComponent<PlayerDataPanel>().setComponents(pd,mechanoidSkins[pd.skinID]);
			index++;
		}
	}



	// Update is called once per frame
	void Update () {
	
	}
}
