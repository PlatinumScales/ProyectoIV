using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioVideoScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find ("AudioSlider").GetComponent<Slider> ().value = AudioListener.volume;
		GameObject.Find("Slider").GetComponent<Slider>().value = QualitySettings.GetQualityLevel();
	}
	
	public void Save(){
		 
		AudioListener.volume = GameObject.Find("AudioSlider").GetComponent<Slider>().value;


		QualitySettings.SetQualityLevel((int)GameObject.Find("Slider").GetComponent<Slider>().value,true);

		Invoke ("Save1",1f);



	}
	public void Save1(){
		AutoFade.LoadLevel(2 ,1,1,Color.black);
	}
}
