using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{


	private PlayerControler PlayerChar;
	private int CurrentHealth;
	public Text Living;
	public Text Health;
	public Text Standing;
	public Text info;

	private bool GameOver = false;

	public int blick = 0;

	// Use this for initialization
	void Start () 
	{
		PlayerChar = GetComponent<PlayerControler> ();
		//Find Current Instance of the player script
		//PlayerChar = GetComponent<PlayerControler>();
		//PlayerChar = FindObjectOfType(typeof(PlayerControler));
		//CurrentHealth = PlayerChar
	}
	
	// Update is called once per frame
	void Update () 
	{
		UpdateText ();	
		blick = PlayerControler.block;
	}

	void UpdateText()
	{
		if (!GameOver) 
		{
			Living.text = "Living: yes";
		}
	
		Health.text = "HP: " + PlayerControler.PlayerHealth;
		Standing.text = "Current Block: " + PlayerControler.block; // Layer Colision Debug code

		// Kevin debug code
		//Pos.text
		info.text = "Kevin: Pos: " + PlayerControler.Position + ", JumpVal: " + PlayerControler.JumpVal + ", Grounded: " + PlayerControler.isGrounded + ", Velocity: " + "X " + PlayerControler.vel.x + ", Y: " + PlayerControler.vel.y;
	}
}
