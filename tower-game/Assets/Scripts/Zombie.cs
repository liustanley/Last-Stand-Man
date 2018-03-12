using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy {

	public Animator anim;

	void Awake () {
		health = 50;
		speed = 20;

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
		
		if (transform.position.x > 13) {
			Flip ();
			Debug.Log("flipped");
		}
	}

	public override void attack () {
		if (Time.time > nextAttack) {
			nextAttack = Time.time + attackSpeed*2;
			playerObject.DamagePlayer (10);
			anim.Play ("ZombieAttack");
			isAttacking = true;
		}
	}

	public override void HitByRay () {
		if (isAttacking) {
			anim.Play ("ZombieAttackHit");

		}
		else {
			anim.Play ("ZombieWalkHit");
		}

		Debug.Log ("Zombie Hit by Ray");
		health -= 10;
		Debug.Log (health);
		checkHealth ();

	}
}
