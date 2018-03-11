using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	public Transform Enemy;
	public GameObject spPoints;
	private SpawnPoints spScript;

	public float timeToSpawn = 2;
	private float nextSpawn = 0;

	private int level = 2; //first level start at int 2 for log scale
	private int difficulty = 4; // increase for more enemies, decrease for less

	void Start () {
		spScript = spPoints.GetComponent<SpawnPoints> ();
		setupLevel (level);
	}

	void Update () {
		if (PauseMenuManager.gameIsPaused) {
			//anything that would happen when game is paused
			//if it does nothing:
			return ;

		}
		
	}

	public void setupLevel (int level)
	{
		int enemyCount = (int)(Mathf.Log (level, 2f) * difficulty);
		spawnEnemy (enemyCount);
	}

	public static void KillPlayer (Player player) {
		Destroy (player.gameObject);
	}

	private void spawnEnemy (int count) {
		for (int i = 0; i < count; i++) {
			if (Time.time > nextSpawn) {
				nextSpawn = Time.time + timeToSpawn + Random.Range(-0.5f, 0.5f);
				Transform sp = spScript.spawnPoints[Random.Range(0,spScript.spawnPoints.Length-1)];
				Instantiate (Enemy, sp.position, sp.rotation);
				Debug.Log ("Spawned enemy");
			}

		}

	}
}
