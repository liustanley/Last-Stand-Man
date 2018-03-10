using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightBehavior : MonoBehaviour {

	private float currentAngle = 0;
	public float rotationSpeed;
	public float smooth = 0.5f;

	private Quaternion goToAngle;

	// Update is called once per frame
	void Update () {

		if (PauseMenuManager.gameIsPaused) {
			//Anything that would happen when the game is paused
			//if code should not run while game is paused, include the following:
			return;
		}

		if (Input.GetKeyDown (KeyCode.Z)) {
			currentAngle += rotationSpeed;
		}
		else if (Input.GetKeyDown (KeyCode.X)) {
			currentAngle -= rotationSpeed;
		} 
		goToAngle = Quaternion.Euler (new Vector3 (0, 0, currentAngle));


		transform.rotation = Quaternion.Lerp (transform.rotation, goToAngle, smooth);
	}
}
