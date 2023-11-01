using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerRocket : MonoBehaviour
{
	public GameObject RocketExplosionGO; //Explosion prefab

	float speed;

	void Start()
	{
		speed = 10f;
		//transform.position = new Vector3(transform.position.x, transform.position.y, -6);
	}


	void Update()
	{

		//Get the Rocket's current position
		Vector3 position = transform.position;

		//Compute the Rocket's new position
		position = new Vector3(position.x, position.y + speed * Time.deltaTime, position.z = -6);

		//Update the Rocket's position
		transform.position = position;

		//If the Rocket went outside the screen at the top, then destroy the bullet
		if (transform.position.y > 4)
		{
			Destroy(gameObject);
		}

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		//Detect collision of the player bullet with an enemy ship
		if (col.tag == "EnemyShipTag")
		{
			Destroy(gameObject);

			GameObject explosion = (GameObject)Instantiate(RocketExplosionGO);

			//Set the position of the explosion
			explosion.transform.position = transform.position;
		}
	}
}

