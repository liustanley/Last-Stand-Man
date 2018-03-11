using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;      //Allows us to use SceneManager
using UnityEngine.UI;

//Player inherits from MovingObject, our base class for objects that can move, Enemy also inherits from this.
public class Player : MonoBehaviour
{
	public int health = 100;
	public SpriteRenderer HealthBarFill;
	public AudioClip[] playerHurt;

	public GameObject gameOverText;

	public bool gameOver = false;

	public void DamagePlayer (int damage) {

		int i = Random.Range (0, playerHurt.Length);
		GetComponent<AudioSource> ().clip = playerHurt [i];
		GetComponent<AudioSource> ().Play ();

		health -= damage;
		//Debug.Log (health + " health remaining");
		if (health <= 0) {
			gameOverText.SetActive (true);
			gameObject.SetActive (false);
			gameOver = true;
		}
	}

	public void showHealth()
	{
		HealthBarFill.size = new Vector2 ((2.0f * health) / 100f, 0.1f);
		if (health <= 0) {
			HealthBarFill.size = new Vector2 (0, 0.1f);
		}
	}

	public float speed;
	public float moveTime;
	public LayerMask blockingLayer;

	private Rigidbody2D rb2D;
	private float inverseMoveTime;

	bool facingRight = true;
	Transform playerGraphics; // Reference to the graphics so we can change direction

	public GameObject playerArm;
	private ArmRotation armScript;
	public Transform firePoint;

	void Awake()
	{
		playerGraphics = transform.FindChild ("Graphics");
		if (playerGraphics == null)
		{
			Debug.LogError ("There is no Graphics object as a child of the player");
		}
	}

	// Use this for initialization
	void Start()
	{
		rb2D = GetComponent<Rigidbody2D> ();
		inverseMoveTime = 1f / moveTime;
		armScript = playerArm.GetComponent<ArmRotation> ();
	}

	private void Update ()
	{
		showHealth ();

		if (PauseMenuManager.gameIsPaused) {
			//Anything that would happen when the game is paused
			//if code should not run while game is paused, include the following:
			return;
		}

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
//			Move (horizontal,vertical);
			if (horizontal < 0 && facingRight) {
				//Flip ();
//				armScript.rotationOffset += 180;
			}
			else if (horizontal > 0 && !facingRight){
				//Flip ();
//				armScript.rotationOffset -= 180;
			}
		}
	}

	private void checkMouse () {
		Vector3 mousePos = Input.mousePosition;


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

	void Flip()
	{
		facingRight = !facingRight;

		Vector3 theScale = playerGraphics.localScale;
		theScale.x *= -1;
		playerGraphics.localScale = theScale;

		theScale = firePoint.localScale;
		theScale.x *= -1;
		firePoint.localScale = theScale;
	}
} 