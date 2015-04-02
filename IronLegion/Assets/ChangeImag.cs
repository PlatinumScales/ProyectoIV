using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeImag : MonoBehaviour {
	 
	 
	private Texture img1;
	private Texture img2;
	private Texture img3;
	private Texture img4;
	// Use this for initialization
	public void Change (string pImage) {
		//****HAY QUE CREAR UNA CARPETA QUE SE LLAME RESOURCES sino no sirve
		img1 = (Texture)Resources.Load("Scenes/CAMPAMENTDRON");
		img2=(Texture)Resources.Load("Scenes/RAGNAROCK");
		img3=(Texture)Resources.Load("Scenes/WASTELANDDRON");

		if(pImage.Equals("1")){
			img4=img1;
			 
		}
		if(pImage.Equals("2")){
			img4=img3;
		}
		if(pImage.Equals("3")){
			img4=img2;
		}
		GameObject.FindGameObjectWithTag("BASEIMAGE").GetComponent<RawImage>().texture = 
			img4;

	}


}
