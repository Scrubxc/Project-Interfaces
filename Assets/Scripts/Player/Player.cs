using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public float shipSpeed = 100.0f; // Speed of Spaceship
	public float leftX = -3.4f; // Minimum left X position
	public float rightX = 3.4f;  // Maximum right X position

	public GameObject GameManagerGO; //reference to game manager

	public GameObject PlayerBulletGO; //Bullet Prefab
	public GameObject BulletPosition01;
	public GameObject BulletPosition02;
	public GameObject ExplosionGO; //Explosion Prefab

	//Reference to the lives UI text
	public Text LivesUIText;

	const int MaxLives = 3; //Maximum player lives
	int lives; //current player lives

	public void Init()
	{
		lives = MaxLives;

		//Starting position in float (double doesn't work)
		float yPos = -1.218f;



		//Update the lives UI text
		LivesUIText.text = lives.ToString();

		//Reset the player position to the center of the screen
		transform.position = new Vector2(0, yPos);

		//set this player game object to active
		gameObject.SetActive (true);
	}
	// Update is called once per frame
	void Update()
	{
		//ship shooting function
		Shooting();	

		//ship movement function
		shipMovement();

	}

	public void Shooting()
	{
		//Fire bullets when spacebar is pressed
		if (Input.GetKeyDown("space"))
		{
			//Instantiate the first bullet
			GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGO);

			//Set the bullet1 initial position
			bullet01.transform.position = BulletPosition01.transform.position;

			//Instantiate the second bullet
			GameObject bullet02 = (GameObject)Instantiate(PlayerBulletGO);

			//Set the bullet2 initial positon
			bullet02.transform.position = BulletPosition02.transform.position;
		}
	}

	public void shipMovement()
	{
		// Get the scroll wheel input
		float scrollInput = Input.GetAxis("Mouse ScrollWheel");

		// Calculate the new position based on the scroll input
		Vector3 newPosition = transform.position + Vector3.right * scrollInput * shipSpeed * Time.deltaTime;

		// Clamp the new position within the specified range
		newPosition.x = Mathf.Clamp(newPosition.x, leftX, rightX);

		// Check if the spaceship is at the left or right edge
		if (newPosition.x == leftX || newPosition.x == rightX)
		{
			// If at the edge, set the velocity to zero to stop moving
			GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		}
		else
		{
			// Update the position of the spaceship
			transform.position = newPosition;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		//Detect collision of the player ship with an enemy ship, or with an enemy bullet
		if ((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
		{
			PlayExplosion();

			//Subtract one life
			lives--;
			LivesUIText.text = lives.ToString(); //update lives UI text

			if (lives == 0)
			{
				//Change game manager state to game over state
				GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);

				//Hide the player's ship
				gameObject.SetActive(false);
			}
		}
	}

	//Function to Instantiate an explosion
	void PlayExplosion()
	{
		GameObject explosion = (GameObject)Instantiate(ExplosionGO);

		//Set the position of the explosion
		explosion.transform.position = transform.position;
	}
}






