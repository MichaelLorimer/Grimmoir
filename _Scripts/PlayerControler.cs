using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------
// -------- NEEDS ----------------------------
//============================================

//Movement
	//- WD, Space = jump
	//- Graviity

//Player
	//Health
	//Power
	//Spells

public class PlayerControler : MonoBehaviour 
{
	//Player Dater
	static public int PlayerHealth; // Defined at 50 in the Editor
	public Rigidbody2D Player;		// Holds the Player(Kevin) RigidBody

	// -- Movement Data
	public float Speed;		//Movement speed: Set to 5f in the editor
	public int Gravity = 1; //Gravioty Value ---- Not Used ----

	// - Jump
	public Transform GroundCheck; //Holds the GroundCheckTransform Object attached to the Player (defined in editor)
	public LayerMask GroundLayer; //Holds the layer to check if grounded

	private bool Jumped = false; 	//Bool to determine if the Player has jumped (to disable infinite jump)
	static public bool isGrounded = true; //Bool to determine if the Player is grounded
	static public float JumpVal;			//Float to store the jump force


	//Debug info 
	static public int block;
	static public Vector2 Position;
	// JumpVal 
	//isGrounded


	// Use this for initialization
	void Start () 
	{
		PlayerHealth = 50; // Working Value
		Player = GetComponent<Rigidbody2D> (); //Find and Cache component
		Speed = 5;	//Working Value
	}

	void FixedUpdate()
	{
		//check grounded
		Position = Player.transform.position;
	}

	// Update is called once per frame
	void Update () 
	{

		isGrounded = Physics2D.OverlapCircle (GroundCheck.position, 0.01f, GroundLayer);
		Vector2 Grav = Player.velocity;
		Grav.y = -Gravity;
		Player.velocity = Grav;
		//Movement 
		//float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		//float moveVertical = Input.GetAxisRaw ("Vertical");
	
		//Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		//Player.AddForce (movement * Speed);
		if (Input.GetKey (KeyCode.D)) 
		{
			Vector2 Pos = Player.transform.position;
			Pos.x += 10 * Time.deltaTime;
			Player.transform.position = Pos;
		}
		if (Input.GetKey (KeyCode.A)) 
		{
			Vector2 Pos = Player.transform.position;
			Pos.x -= 10 * Time.deltaTime;
			Player.transform.position = Pos;
		}
		//Jump

		/*if (Input.GetKey (KeyCode.W)) 
		{
			Player.AddForce (new Vector2 (0, JumpVal));	
			Jumped = true;
		}*/
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		block = coll.gameObject.layer;
		if (coll.gameObject.layer == 8 && (Input.GetKey (KeyCode.W))) 
		{
			Player.AddForce(new Vector2 (0, JumpVal));
		}
	}
}
