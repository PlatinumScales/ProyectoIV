using UnityEngine;
using System.Collections;

public class pauseMenu : MonoBehaviour {
	public bool pauseGame = false;
	public RectTransform pausedGui;
	public RectTransform confWin; 
	private bool lockPausedGui = false;

	void Start () {
		Cursor.visible = false;
		Screen.lockCursor = true;
		confWin.gameObject.SetActive(false);
		pausedGui.gameObject.SetActive(false);
	}

	void Update(){
		if(!lockPausedGui) {
			if(Input.GetKeyDown("p")|| Input.GetButtonDown ("Cancel")){
				pauseGame = !pauseGame;
			}

			if(pauseGame == true){
				Time.timeScale = 0;
				pauseGame = true;
				pausedGui.gameObject.SetActive(true);
				Cursor.visible = true;
				Screen.lockCursor = false;

			} else{
				Time.timeScale = 1;
				pauseGame = false;
				pausedGui.gameObject.SetActive(false);

				Cursor.visible = false;
				Screen.lockCursor = true;
			}
		}
	}
	
	public void OpenConfirmationWindow(){
		confWin.gameObject.SetActive(true);
		lockPausedGui = true;
	}
	
	public void next(string next){
		lockPausedGui = false;
		pauseGame = false;
		Cursor.visible = true;
		Screen.lockCursor = false;
		confWin.gameObject.SetActive(false);
		AutoFade.LoadLevel(next,1,1,Color.black);
	}

	public void continueGame(){
		lockPausedGui = false;
		pauseGame = false;
		confWin.gameObject.SetActive(false);
	}
}
