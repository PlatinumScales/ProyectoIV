using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Intro : MonoBehaviour {
	public RectTransform slidePanel1;
	public RawImage slidePanel2;
	public float speed = 20f;
	public float growth = 30f;
	public float clock; 
	public Vector2 pos;
	public Vector3 pScale;
	public float ratio;

	// Use this for initialization
	void Start () {
		pos = slidePanel1.localPosition;
		pScale =slidePanel2.transform.localScale;
		ratio = (pScale.x - 0.9f)/growth;
	}
	
	// Update is called once per frame
	void Update () {
		if (clock < 60f){
			pos.x -= Time.deltaTime*speed;
			slidePanel1.localPosition = pos;
		}
		if (clock > 60 && clock < 90){
			pScale -= new Vector3(ratio*Time.deltaTime,ratio*Time.deltaTime,0);
			slidePanel2.transform.localScale = pScale;
		}
		clock += Time.deltaTime;
	}
}
