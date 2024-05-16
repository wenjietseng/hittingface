using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FadingEffect : MonoBehaviour {

	private Renderer fadeRenderer;
	bool fadeIn = false;
	bool fadeOut = false;
	float counter = 0;
	float speed = 3.0f;
	Action fadeInCallBack;
	Action fadeOutCallBack;
	// Use this for initialization
	void Start () {
		fadeRenderer = GameObject.Find("FadeEffect").GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(fadeIn){
			counter -= Time.deltaTime * speed;
			fadeRenderer.sharedMaterial.SetFloat("_Alpha", counter);
			if(counter <= 0){
				fadeIn = false;
				fadeRenderer.sharedMaterial.SetFloat("_Alpha", 0);
				if(fadeInCallBack != null)
					fadeInCallBack();
			}
		}
		if(fadeOut){
			counter += Time.deltaTime * speed;
			fadeRenderer.sharedMaterial.SetFloat("_Alpha", counter);
			if(counter >= 1.0f){
				fadeOut = false;
				fadeRenderer.sharedMaterial.SetFloat("_Alpha", 1);
				if(fadeOutCallBack != null)
					fadeOutCallBack();
			}
		}
	}
	public void fadeOutEffect(Action callBack = null){
		counter = 0;
		fadeOut = true;
		fadeOutCallBack = callBack;
	}
	public void fadeInEffect(Action callBack = null){
		counter = 1;
		fadeIn = true;
		fadeInCallBack = callBack;
	}
}
