using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class GuiManager : MonoBehaviour
{
	public Health character;
	public Image  shieldBar;
	public Image  healthBar;
	public Text shieldTxt;
	public Text healthTxt;
/*
	public InstantGuiSlider healthBar;
	public InstantGuiSlider shieldBar;
	// Use this for initialization
	void Start () {
		//Set healthBar
		healthBar.value = 0;
		healthBar.max = 0;
		healthBar.min = 0;
		healthBar.shownValue = 100;
		//Set ShieldBar
		shieldBar.value = 0;
		shieldBar.max = 0;
		shieldBar.min = 0;
		shieldBar.shownValue = 100;

	}
	
	// Update is called once per frame
	void Update () {
			shieldBar.shownValue = (health.currentShield / health.maxShield) * 100f;
			shieldBar.max = 100 - (health.currentShield / health.maxShield) * 100f;
			healthBar.shownValue = (health.currentHealth / health.maxHealth) * 100f;
			healthBar.max = 100 - (health.currentHealth / health.maxHealth) * 100f;
		}
		*/


		void Start ()
		{
		}

		void Update ()
		{
				shieldBar.fillAmount = (character.currentShield * 1f) / (character.maxShield * 1f);
				healthBar.fillAmount = (character.currentHealth * 1f) / (character.maxHealth * 1f);
				if (healthBar.fillAmount > 0.6f) {
						healthBar.color = Color.green;
				} else if (healthBar.fillAmount < 0.3f) {
						healthBar.color = Color.red;
				} else {
						healthBar.color = Color.yellow;	
				}
		shieldTxt.text = "" + 	(int)Math.Round(character.currentShield) ;
		healthTxt.text = "" + (int)Math.Round(character.currentHealth);
	}


}