using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed = 5.0f; // Adjust this to set the speed of your spaceship
	public float minX = -5.0f; // Minimum X position
	public float maxX = 5.0f;  // Maximum X position

	// Update is called once per frame
	void Update()
	{
		// Get the scroll wheel input
		float scrollInput = Input.GetAxis("Mouse ScrollWheel");

		// Calculate the new position based on the scroll input
		Vector3 newPosition = transform.position + Vector3.right * scrollInput * speed * Time.deltaTime;

		// Clamp the new position within the specified range
		newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

		// Check if the spaceship is at the left or right edge
		if (newPosition.x == minX || newPosition.x == maxX)
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
