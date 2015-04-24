using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class GuiManager : MonoBehaviour
{
	public RawImage  mImage;
	public Texture gameOverTexture;
	public Animator guiAnimator;
	public Health character;
	public Image  shieldBar;
	public Image  healthBar;
	public Text shieldTxt;
	public Text healthTxt;
	private bool targettt=false;


		void Start ()
		{
		}

		void Update ()
		{


		 
			Debug.LogWarning("Finding");
			//if(GameObject.FindGameObjectWithTag ("Player")!=null){
		try	{
		character = GameObject.FindGameObjectWithTag ("Player").GetComponent<Health>();
			

		Debug.Log (character.maxShield.ToString());
		 
		 
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

		if(character.currentHealth <= 0){
			mImage.texture = gameOverTexture;
			guiAnimator.SetTrigger("FadeIn");
			Cursor.visible = true;
			Screen.lockCursor = false;
			AutoFade.LoadLevel("menuMission" , 8, 2, Color.black);
		}
			 
			
		}catch(Exception ex)
		{
		}
	}


}