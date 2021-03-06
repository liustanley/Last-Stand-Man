﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy : MonoBehaviour {

	public GameMaster gm;
	public GameObject epPoints;
	private EnemyTargetPoints epScript;
	public Player playerObject;

	public Transform enemyTarget;
	public float speed = 20;
	public float attackSpeed = 50;
	public float nextAttack = 0;
	private Vector2 end;

	public int health = 30;

	public bool isAttacking = false;

	public AudioClip[] noises;


	// Use this for initialization
	void Start () {
		int i = Random.Range (0, noises.Length);
		GetComponent<AudioSource> ().clip = noises [i];
		GetComponent<AudioSource> ().Play ();

		StartCoroutine (tryToMakeNoise ());

		gm = GameObject.Find ("GM").GetComponent<GameMaster>();
		epPoints = GameObject.Find ("Enemy Target Points");
		epScript = epPoints.GetComponent<EnemyTargetPoints> ();
		playerObject = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();

		Vector2 start = transform.position;
		end = closestTarget ();

	}
	
	// Update is called once per frame



	public void checkHealth () {
		if (health <= 0) {
			Destroy (gameObject);
			gm.addKill ();
			Debug.Log ("added kill");
		}
	}

	public abstract void attack ();

	public abstract void HitByRay ();

	Vector2 closestTarget () { // returns index of closest target
		Transform[] targetPoints = epScript.targetPoints;
		Vector3 close = transform.position - targetPoints [0].position;
		int closeInd = 0;
		for (int i = 1; i < targetPoints.Length; i++) {
			Vector3 current = transform.position - targetPoints [i].position;
			if (current.magnitude < close.magnitude) {
				close = current;
				closeInd = i;
			}
		}
		Vector2 result = new Vector2 (targetPoints[closeInd].position.x, targetPoints[closeInd].position.y);

		return result;
	}

	public void move () {
		Vector2 start = transform.position;
		Vector2 direction = end - start;

		direction.Normalize ();
		Vector2 movement = (direction * speed / 10 * Time.deltaTime);
		Vector3 newPosition = new Vector3 (transform.position.x + movement.x, transform.position.y + movement.y);
		transform.position = newPosition;

		if (Mathf.Abs (end.x - transform.position.x) < 0.1 && Mathf.Abs(end.y - transform.position.y) < 0.1)
			isAttacking = true;

	}

	IEnumerator tryToMakeNoise()
	{
		yield return new WaitForSeconds (5.0f);
		int chance = Random.Range (1, 100);
		if (chance > 80) {
			int i = Random.Range (0, noises.Length);
			GetComponent<AudioSource> ().clip = noises [i];
			GetComponent<AudioSource> ().Play ();
		}

		StartCoroutine (tryToMakeNoise ());
	}

	public void Flip()
	{
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		sr.flipX = true;
	}
}
