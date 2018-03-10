using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetPoints : MonoBehaviour {

	public Transform[] targetPoints; //top, bottom, left, right

	void Awake ()
	{
		targetPoints = new Transform[transform.childCount];
		for (int i = 0; i < targetPoints.Length; i++)
		{
			targetPoints[i] = transform.GetChild (i);

		}
	}
}
