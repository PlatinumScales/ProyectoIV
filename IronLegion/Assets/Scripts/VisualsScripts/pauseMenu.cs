using UnityEngine;
using System.Collections;

public class pauseMenu : MonoBehaviour {
	public bool pauseGame = false;
	public RectTransform pausedGui;
	public RectTransform confWin; 
	 

	void Start () {
		Cursor.visible = false;
		Screen.lockCursor = true;
//		confWin.gameObject.SetActive(false);
		pausedGui.gameObject.SetActive(false);
	}

	void Update(){
		 
			if(Input.GetKeyDown("p")|| Input.GetButtonDown ("Cancel")){
				pauseGame = !pauseGame;
				if(pauseGame == true){
					//Debug.LogWarning("Lock");
					Time.timeScale = 0;
					pauseGame = true;
					pausedGui.gameObject.SetActive(true);
					Cursor.visible = true;
					Screen.lockCursor = false;
					
				} else{
					//Debug.LogWarning("UnLock");
					Time.timeScale = 1;
					pauseGame = false;
					pausedGui.gameObject.SetActive(false);
					
					Cursor.visible = false;
					Screen.lockCursor = true;
				}
			}


		 
	}
	
	public void OpenConfirmationWindow(){
		AutoFade.LoadLevel(2,1,1,Color.black);
		//confWin.gameObject.SetActive(true);
		 
	}
	
	public void QuitPause(){

		Time.timeScale = 1;
		pauseGame = false;
		pausedGui.gameObject.SetActive(false);
		
		Cursor.visible = false;
		Screen.lockCursor = true;
	
		AutoFade.LoadLevel(2,1,1,Color.black);
	}

	public void continueGame(){
		//lockPausedGui = true;
		//pauseGame = false;
		//confWin.gameObject.SetActive(false);


		Time.timeScale = 1;
		pauseGame = false;
		pausedGui.gameObject.SetActive(false);
		Cursor.visible = true;
		Screen.lockCursor = true;

		 
	}
}
