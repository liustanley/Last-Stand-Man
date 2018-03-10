using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonActions : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject optionsMenu;


	public void LoadSceneButton(string name)
	{
		StartCoroutine (ChangeScene (name, 1.5f));
	}

	public void mainToOptionsButton(float waitTime)
	{
		StartCoroutine (mainToOptions(waitTime));
	}

	public void optionsToMainButton(float waitTime)
	{
		StartCoroutine (optionsToMain(waitTime));
	}

	public void quitGame(float waitTime)
	{
		StartCoroutine (quitAfterTime (waitTime));
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

	private IEnumerator optionsToMain(float waitTime)
	{
		yield return new WaitForSeconds (waitTime);
		optionsMenu.SetActive (false);
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
