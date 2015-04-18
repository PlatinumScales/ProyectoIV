using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class MissionLoader : MonoBehaviour {
	public string mission ;
	public RawImage  missionPreview;


	public void setMission(string missionName){
		mission = missionName;
	}
	
	public void MissionPreview( Texture texture){
		missionPreview.texture = texture;
	}

	public void LoadMission(){
		AutoFade.LoadLevel (mission , 1, 2, Color.black);

	}

	public void back(){
		AutoFade.LoadLevel ("menuUI" , 1, 2, Color.black);
	}
}
