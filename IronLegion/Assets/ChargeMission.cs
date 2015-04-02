using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChargeMission : MonoBehaviour {

	public void Charge()
	{


		string vName = GameObject.FindGameObjectWithTag("BASEIMAGE").GetComponent<RawImage>().texture.name;

		int vMission=4;
		
		if(vName.Equals("CAMPAMENTDRON")){
			vMission=4;
			
		}

		if(vName.Equals("WASTELANDDRON")){
			vMission=5;
		}
		if(vName.Equals("RAGNAROCK")){
			vMission=6;
		}
		AutoFade.LoadLevel(vMission ,1,1,Color.black);

	}
}
