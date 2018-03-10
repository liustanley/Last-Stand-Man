using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject epPoints;
	private EnemyTargetPoints epScript;

	public Transform enemyTarget;
	public float speed = 1;
	private Vector2 end;

	public int health = 30;


	// Use this for initialization
	void Start () {
		epPoints = GameObject.Find ("Enemy Target Points");
		epScript = epPoints.GetComponent<EnemyTargetPoints> ();

		Vector2 start = transform.position;
		end = closestTarget ();
	}
	
	// Update is called once per frame
	void Update () {
		move ();
		checkHealth ();
	}

	void checkHealth () {
		if (health <= 0)
			Destroy (gameObject);
	}

	void HitByRay () {
		Debug.Log ("I was hit by a Ray");
		health -= 10;
		Debug.Log (health);
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

	}
}
