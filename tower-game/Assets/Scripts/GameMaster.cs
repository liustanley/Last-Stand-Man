using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	public Transform Enemy;
	public GameObject spPoints;
	private SpawnPoints spScript;

	public float timeToSpawn = 10;

	public static void KillPlayer (Player player) {
		Destroy (player.gameObject);
	}

	void Start () {
		spScript = spPoints.GetComponent<SpawnPoints> ();
		spawnEnemy ();
		spawnEnemy ();
		spawnEnemy ();
		spawnEnemy ();
	}

	void Update () {
		
	}

	private void spawnEnemy () {
		//Instantiate (BulletTrailPrefab, firePoint.position, firePoint.rotation);
		Transform sp = spScript.spawnPoints[Random.Range(0,spScript.spawnPoints.Length-1)];
		Instantiate (Enemy, sp.position, sp.rotation);

	}
}
