using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class SpawnPoints : MonoBehaviour {

	public Transform[] spawnPoints;

	void Awake ()
	{
		spawnPoints = new Transform[transform.childCount];
		for (int i = 0; i < spawnPoints.Length; i++)
		{
			spawnPoints[i] = transform.GetChild (i);

		}
	}
}
