using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour {

	public int rotationOffset = 90;
	
	// Update is called once per frame
	void Update () {
		if (PauseMenuManager.gameIsPaused) {
			//Anything that would happen when the game is paused
			//if code should not run while game is paused, include the following:
			return;
		}

		Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;  // subtracting the position of the player from the mouse position
		difference.Normalize ();  // normalizing the vector. Meaning that all the sum of the vector will be equal to 1.

		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;  // find the angle in degrees
		transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);
	}
}
