using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;      //Allows us to use SceneManager
using UnityEngine.UI;

//Player inherits from MovingObject, our base class for objects that can move, Enemy also inherits from this.
public class Player : MonoBehaviour
{
	public float speed;
	public float moveTime;
	public LayerMask blockingLayer;

	private Rigidbody2D rb2D;
	private float inverseMoveTime;

	// Use this for initialization
	void Start()
	{
		rb2D = GetComponent<Rigidbody2D> ();
		inverseMoveTime = 1f / moveTime;
	}

	private void Update ()
	{
		int horizontal = 0;     //Used to store the horizontal move direction.
		int vertical = 0;       //Used to store the vertical move direction.


		//Get input from the input manager, round it to an integer and store in horizontal to set x axis move direction
		horizontal = (int) (Input.GetAxisRaw ("Horizontal"));

		//Get input from the input manager, round it to an integer and store in vertical to set y axis move direction
		vertical = (int) (Input.GetAxisRaw ("Vertical"));

		//Check if moving horizontally, if so set vertical to zero.
		if(horizontal != 0)
		{
			vertical = 0;
		}

		//Check if we have a non-zero value for horizontal or vertical
		if(horizontal != 0 || vertical != 0)
		{
			Move (horizontal,vertical);
		}
	}

	public void Move (int xDir, int yDir)
	{
		Vector2 start = transform.position;
		Vector2 end = (start + new Vector2 (xDir, yDir));
		rb2D.MovePosition (end);
//		SmoothMovement (end);

	}

	public IEnumerator SmoothMovement (Vector3 end)
	{
		float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

		while (sqrRemainingDistance > float.Epsilon)
		{
			Vector3 newPosition = Vector3.MoveTowards (rb2D.position, end, inverseMoveTime * Time.deltaTime);
			rb2D.MovePosition (newPosition);
			sqrRemainingDistance = (transform.position - end).sqrMagnitude;
			yield return null; //wait for frame before continue
		}
	}

}