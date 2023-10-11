using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float shipSpeed = 100.0f; // Speed of Spaceship
	public float leftX = -3.4f; // Minimum left X position
	public float rightX = 3.4f;  // Maximum right X position

	// Update is called once per frame
	void Update()
	{
		shipMovement();
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






