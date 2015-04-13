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
	public List<GameObject> mechanoidSkins;

	// Change panel name to i then onclic(Gamecontroler.Playerdata = pdl[i])

	// Use this for initialization
	void Start () {
		PlayerDataManager.pdm.playerNames.ForEach(delegate(string name){
			pdl.Add(PlayerDataManager.pdm.Load(name));
		});
		float x = 0f;
		float y = 0f;

		bool flag = true;
		int index = 0;
		foreach(PlayerData pd in pdl){
			RectTransform g =  Instantiate (loadPanel) as RectTransform; 
			g.name = ""+ index;
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
			Button b = g.GetComponentInChildren<Button>();
			b.onClick.AddListener(()=> LoadPlayer(pd));

			index++;
		}
	}

	void LoadPlayer (PlayerData pd){
		GameControl.control.playerData = pd;
		GameControl.control.mechanoidSkin = Instantiate (mechanoidSkins[pd.skinID], transform.position, transform.rotation) as GameObject;
		GameControl.control.mechanoidSkin.transform.SetParent(GameControl.control.transform);
		AutoFade.LoadLevel ("menuMission", 1, 2, Color.gray);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
