using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkinUnlock : MonoBehaviour {
	public Button titan;
	public RectTransform purchaseWindow; 
	public GameObject btn;
	// Use this for initialization
	void Start () {
		if(PlayerDataManager.pdm.purchases.Contains("Titan")){
			titan.enabled = true;
			titan.interactable = true;
			btn.SetActive(false);
		}
	}
	
	public void openPurchasWdow(string purchaseName){
		purchaseWindow.gameObject.SetActive(true);
	}

	public void cancel (){
		purchaseWindow.gameObject.SetActive(false);
	}

	public void accept(){
		PlayerDataManager.pdm.purchases.Add("Titan");
		PlayerDataManager.pdm.SavePurchases();
		titan.enabled = true;
		titan.interactable = true;
		btn.SetActive(false);
	}

}
