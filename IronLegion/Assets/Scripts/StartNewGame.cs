using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartNewGame : MonoBehaviour
{
		public InputField nameField;
		public Text errorText;

		void Start ()
		{
				errorText.enabled = false;
		}

		public void StartGame ()
		{
				if (nameField.text.Equals ("")) {
						errorText.enabled = true;
				} else {
						GameControl.control.playerData.playerName = nameField.text;
						GameControl.control.Save ();
						AutoFade.LoadLevel ("menuMission", 1, 2, Color.gray);
				}

		}
}
