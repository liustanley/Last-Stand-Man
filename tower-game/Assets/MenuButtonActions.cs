using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonActions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadSceneButton(string name)
	{
		StartCoroutine (ChangeScene (name, 1.5f));
	}

	IEnumerator ChangeScene(string SceneName, float waitTime)
	{
		yield return new WaitForSeconds (waitTime);
		SceneManager.LoadScene (SceneName);
	}
}
