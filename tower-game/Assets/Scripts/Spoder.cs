using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spoder : Enemy {

	public Animator anim;

	// Use this for initialization
	void Awake () {
		health = 30;
		speed = 50;

		anim = GetComponent<Animator> ();

	}

	void Update () {
		if (PauseMenuManager.gameIsPaused) {
			//Anything that would happen when the game is paused
			//if code should not run while game is paused, include the following:
			return;
		}
			
		if (!isAttacking)
			move ();
		else
			attack ();

		if (transform.position.x < 13) {
			Flip ();
			Debug.Log("flipped");
		}

	}

	public override void attack () {
		if (Time.time > nextAttack) {
			nextAttack = Time.time + attackSpeed*2;
			playerObject.DamagePlayer (10);
			anim.Play ("SpoderAttack");
			isAttacking = true;
		}
	}

	public override void HitByRay () {
		if (isAttacking) {
			anim.Play ("SpoderAttackHit");

		}
		else {
			anim.Play ("SpoderWalkHit");
		}

		Debug.Log ("Spider Hit by Ray");
		health -= 10;
		Debug.Log (health);
		checkHealth ();

	}
}
