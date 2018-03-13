using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuButtonActions : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject optionsMenu;
	public GameObject controlsMenu;
	public GameObject credits;

	public AudioMixer mixer;

	void Start()
	{
		//Set settings to desired player value

		mixer.SetFloat ("volume", PlayerPrefs.GetFloat("Volume"));
		QualitySettings.SetQualityLevel (PlayerPrefs.GetInt("QualityIndex")); 

		if (PlayerPrefs.GetInt ("Fullscreen") == 1) {
			Screen.fullScreen = true;
		} 
		else {
			Screen.fullScreen = false;
		}

	}


	public void LoadSceneButton(string name)
	{
		StartCoroutine (ChangeScene (name, 1.5f));
	}

	public void mainToOptionsButton(float waitTime)
	{
		StartCoroutine (mainToOptions(waitTime));
	}

	public void mainToControlsButton(float waitTime)
	{
		StartCoroutine (mainToControl(waitTime));
	}

	public void mainToCreditsButton(float waitTime)
	{
		StartCoroutine (mainToCredits(waitTime));
	}

	public void optionsToMainButton(float waitTime)
	{
		StartCoroutine (optionsToMain(waitTime));
	}

	public void controlsToMainButton(float waitTime)
	{
		StartCoroutine (controlToMain(waitTime));
	}

	public void creditsToMainButton(float waitTime)
	{
		StartCoroutine (creditsToMain(waitTime));
	}



	public void quitGame(float waitTime)
	{
		StartCoroutine (quitAfterTime (waitTime));
	}

	public void SetVolume(float volume)
	{
		PlayerPrefs.SetFloat ("Volume", volume);
		mixer.SetFloat ("volume", PlayerPrefs.GetFloat("Volume"));
	}

	public void SetQuality(int index)
	{
		PlayerPrefs.SetInt ("QualityIndex", index);
		QualitySettings.SetQualityLevel (PlayerPrefs.GetInt("QualityIndex")); 
	}

	public void SetFullscreen(bool fs)
	{
		if (fs) {
			PlayerPrefs.SetInt ("Fullscreen", 1);
		} 
		else {
			PlayerPrefs.SetInt ("Fullscreen", 0);
		}

		if (PlayerPrefs.GetInt ("Fullscreen") == 1) {
			Screen.fullScreen = true;
		} 
		else {
			Screen.fullScreen = false;
		}
	}


	private IEnumerator ChangeScene(string SceneName, float waitTime)
	{
		
		yield return new WaitForSeconds (waitTime);
		PauseMenuManager.gameIsPaused = false;
		SceneManager.LoadScene (SceneName);
	}

	private IEnumerator mainToOptions(float waitTime)
	{
		yield return new WaitForSeconds (waitTime);
		mainMenu.SetActive (false);
		optionsMenu.SetActive (true);
	}

	private IEnumerator mainToControl(float waitTime)
	{
		yield return new WaitForSeconds (waitTime);
		mainMenu.SetActive (false);
		controlsMenu.SetActive (true);
	}

	private IEnumerator mainToCredits(float waitTime)
	{
		yield return new WaitForSeconds (waitTime);
		mainMenu.SetActive (false);
		credits.SetActive (true);
	}

	private IEnumerator optionsToMain(float waitTime)
	{
		yield return new WaitForSeconds (waitTime);
		optionsMenu.SetActive (false);
		mainMenu.SetActive (true);
	}

	private IEnumerator controlToMain(float waitTime)
	{
		yield return new WaitForSeconds (waitTime);
		controlsMenu.SetActive (false);
		mainMenu.SetActive (true);
	}

	private IEnumerator creditsToMain(float waitTime)
	{
		yield return new WaitForSeconds (waitTime);
		credits.SetActive (false);
		mainMenu.SetActive (true);
	}

	private IEnumerator quitAfterTime(float waitTime)
	{
		yield return new WaitForSeconds (waitTime);
		PauseMenuManager.gameIsPaused = false;
		Application.Quit ();
		Debug.Log ("quit Game");
	}
}
