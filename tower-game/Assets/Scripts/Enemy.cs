using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameMaster gm;
	public GameObject epPoints;
	private EnemyTargetPoints epScript;
	private Player playerObject;

	public Transform enemyTarget;
	public float speed = 20;
	public float attackSpeed = 0.5f;
	private float nextAttack = 0;
	private Vector2 end;

	public int health = 30;

	private bool isAttacking = false;


	// Use this for initialization
	void Start () {
		gm = GameObject.Find ("GM").GetComponent<GameMaster>();
		epPoints = GameObject.Find ("Enemy Target Points");
		epScript = epPoints.GetComponent<EnemyTargetPoints> ();
		playerObject = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();

		Vector2 start = transform.position;
		end = closestTarget ();
	}
	
	// Update is called once per frame
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

	}

	void checkHealth () {
		if (health <= 0) {
			Destroy (gameObject);
			gm.addKill ();
			Debug.Log ("added kill");
		}
	}

	void attack () {
		if (Time.time > nextAttack) {
			nextAttack = Time.time + attackSpeed;
			playerObject.DamagePlayer (10);
		}
	}

	void HitByRay () {
		Debug.Log ("I was hit by a Ray");
		health -= 10;
		Debug.Log (health);
		checkHealth ();
	}

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

	void move () {
		Vector2 start = transform.position;
		Vector2 direction = end - start;

		direction.Normalize ();
		Vector2 movement = (direction * speed / 10 * Time.deltaTime);
		Vector3 newPosition = new Vector3 (transform.position.x + movement.x, transform.position.y + movement.y);
		transform.position = newPosition;

		if (Mathf.Abs (end.x - transform.position.x) < 0.1 && Mathf.Abs(end.y - transform.position.y) < 0.1)
			isAttacking = true;

	}
}
