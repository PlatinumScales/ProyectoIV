using UnityEngine;
using System.Collections;

public class NewGame : MonoBehaviour {

	public void NextLevelButton(int pLevel)
	{
		
		
		AutoFade.LoadLevel(pLevel ,1,1,Color.black);
	}
}
