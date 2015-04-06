using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class MissionLoader : MonoBehaviour {
	public int mission = 1;
	public RawImage  missionPreview;

	public void MissionPreview( String textureName){
		missionPreview.texture = (Texture)  Resources.Load(textureName, typeof(Texture));
	}

	public void MissionSet(int missionNumber){
		mission = missionNumber;

	}

	public void LoadMission(){
		AutoFade.LoadLevel (mission + 3, 1, 2, Color.black);

	}


}
