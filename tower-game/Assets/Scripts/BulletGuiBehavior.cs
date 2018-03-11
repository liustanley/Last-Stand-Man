using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGuiBehavior : MonoBehaviour {

	public Weapon playerWep;
	public GameObject[] bulletImgs;
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < bulletImgs.Length; i++) {
			bulletImgs [i].SetActive (true);
			if (playerWep.bullets <= i) {
				bulletImgs [i].SetActive (false);
			}
		}
	}
}
