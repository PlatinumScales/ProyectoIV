using UnityEngine;
using System.Collections;

public class GuiManager : MonoBehaviour {
	public Health health;

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
}
