using UnityEngine;
using System.Collections;

public class PlayerDataPanel : MonoBehaviour {
	public PlayerData pd = new PlayerData();
	public GameObject mechanoidSkin = null;

	public void setComponents(PlayerData pd, GameObject mechanoidSkin){
		this.pd = pd;
		this.mechanoidSkin = mechanoidSkin;
	}

	public void LoadPlayer (){
		GameControl.control.playerData = pd;
		GameControl.control.mechanoidSkin = Instantiate (mechanoidSkin, transform.position, transform.rotation) as GameObject;
		GameControl.control.mechanoidSkin.transform.SetParent(GameControl.control.transform);
		AutoFade.LoadLevel ("menuMission", 1, 2, Color.gray);
	}
}
