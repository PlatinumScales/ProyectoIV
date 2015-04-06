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

		public void StartGame (GameObject mechaSkin)
		{
				if (nameField.text.Equals ("")) {
						errorText.enabled = true;
				} else {
						GameControl.control.playerData.playerName = nameField.text;
						GameControl.control.mechanoidSkin = Instantiate(mechaSkin, transform.position, transform.rotation) as GameObject;
						GameControl.control.mechanoidSkin.transform.parent = GameControl.control.transform;
						GameControl.control.Save ();
						AutoFade.LoadLevel ("menuMission", 1, 2, Color.gray);
				}

		}
}
