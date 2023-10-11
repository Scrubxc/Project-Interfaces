using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float shipSpeed = 100.0f; // Speed of Spaceship
	public float leftX = -3.4f; // Minimum left X position
	public float rightX = 3.4f;  // Maximum right X position

	public GameObject PlayerBulletGO; //Bullet Prefab
	public GameObject BulletPosition01;
	public GameObject BulletPosition02;

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
			GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
		else
		{
			// Update the position of the spaceship
			transform.position = newPosition;
		}
	}
}






