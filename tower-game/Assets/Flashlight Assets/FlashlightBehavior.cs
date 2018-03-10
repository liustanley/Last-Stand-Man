using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FlashlightBehavior : MonoBehaviour {

	private Image flMask;
	private float currentAngle = 0;

	public float rotationSpeed;

	// Use this for initialization
	void Start () {
		flMask = GetComponent<Image> ();

		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			currentAngle += rotationSpeed;
			flMask.transform.rotation = Quaternion.Euler(new Vector3(0,0,currentAngle));
		}
		else if (Input.GetKey (KeyCode.RightArrow)) {
			currentAngle -= rotationSpeed;
			flMask.transform.rotation = Quaternion.Euler(new Vector3(0,0,currentAngle));
		}
	}
}
