using UnityEngine;
using System.Collections;

public class Return : MonoBehaviour {

	public void ReturnPlayer(int pLevel)
	{
		
		
		AutoFade.LoadLevel(pLevel ,1,1,Color.black);
	}
}
