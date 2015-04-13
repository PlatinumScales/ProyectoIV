using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartNewGame : MonoBehaviour
{
	public InputField nameField;
	public Text errorText;
	
	private int sID;
	
	void Start ()
	{
		errorText.enabled = false;
	}
	
	public void setCharacterSkin(int skinID){
		this.sID = skinID;
	}
	
	public void StartGame (GameObject mechaSkin)
	{
		if (nameField.text.Equals ("")) {
			errorText.text = "Please enter your name*";
			errorText.enabled = true;
		} else if(PlayerDataManager.pdm.playerNames.Count == 0  | !PlayerDataManager.pdm.playerNames.Contains(nameField.text)){
			GameControl.control.playerData.playerName = nameField.text;
			GameControl.control.playerData.skinID = sID;
			GameControl.control.playerData.mission = 0;
			GameControl.control.mechanoidSkin = Instantiate(mechaSkin, transform.position, transform.rotation) as GameObject;
			GameControl.control.mechanoidSkin.transform.parent = GameControl.control.transform;
			GameControl.control.playerData.date = System.DateTime.Now.ToString(); 
			PlayerDataManager.pdm.playerNames.Add(nameField.text);
			PlayerDataManager.pdm.Save();
			GameControl.control.Save ();
			AutoFade.LoadLevel ("menuMission", 1, 2, Color.gray);
		} else {
			errorText.text = "Character name already exists";
			errorText.enabled = true;
		}
	}
}
