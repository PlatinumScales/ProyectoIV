using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuUIBehaviour : MonoBehaviour {
	public Button continueBtn;

	// Use this for initialization
	void Start () {
		Cursor.visible = true;
		Screen.lockCursor = false;

		if(PlayerDataManager.pdm == null | PlayerDataManager.pdm.playerNames.Count <= 0){
			continueBtn.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NextLevelButton(string levelName)
	{
		AutoFade.LoadLevel(levelName ,1,1,Color.black);
	}
}
