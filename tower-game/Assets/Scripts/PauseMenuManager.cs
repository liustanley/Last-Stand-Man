using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour {

	public GameObject PauseMenu ;
	public GameObject mainPart;
	public GameObject optionsPart;

	public static bool gameIsPaused = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (PauseMenu.activeSelf) {
				
				resumeGame ();
			} 
			else if (!PauseMenu.activeSelf) {
				
				pauseGame ();
			}
		}
		
	}

	public void resumeGame()
	{
//		Time.timeScale = 1;
		gameIsPaused = false;
		PauseMenu.SetActive (false);
	}

	public void pauseGame()
	{
//		Time.timeScale = 0;

		gameIsPaused = true;

		PauseMenu.SetActive (true);
		mainPart.SetActive (true);
		optionsPart.SetActive (false);
	}
}
