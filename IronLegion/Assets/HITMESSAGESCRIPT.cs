using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HITMESSAGESCRIPT : MonoBehaviour {

	// Use this for initialization
	public void Awake () {
		Text vText = GetComponent<Text>();
		vText.color = Color.clear;
	}
	
	// Update is called once per frame
	public void ShowMessage (string pMessage,Color pColor) {
		Text vText = GetComponent<Text>();
		vText.text = pMessage;
		vText.color = pColor;
		Invoke ("ClearMessage", 1);
	}

		private void ClearMessage(){
			Text vText = GetComponent<Text>();
			vText.color = Color.clear;
		}
}