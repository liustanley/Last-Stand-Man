using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour {

	public Texture2D fadeImage;
	public float fadeSpeed = 1.0f;

	private int drawDepth = -1000;
	private int fadeDir = -1;
	private float alpha = 1.0f;

	
//	// Update is called once per frame
//	void Update () {
//		
//	}

	void OnGUI()
	{
		alpha += (fadeDir * Time.deltaTime) / fadeSpeed;

		alpha = Mathf.Clamp01 (alpha);

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height)  ,fadeImage);


	}

	public void BeginFade(int direction)
	{
		fadeDir = direction;
	}

	void OnLevelWasLoaded()
	{
		alpha = 1;
		BeginFade (-1);
	}
}
