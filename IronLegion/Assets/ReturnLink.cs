using UnityEngine;
using System.Collections;

public class ReturnLink : MonoBehaviour {

	public void NextLevelButton(int pLevel)
	{
		
		
		AutoFade.LoadLevel(pLevel ,1,1,Color.black);
	}

	public void NextLevelButton(string levelName)
	{
		AutoFade.LoadLevel(levelName ,1,1,Color.black);
	}
}
