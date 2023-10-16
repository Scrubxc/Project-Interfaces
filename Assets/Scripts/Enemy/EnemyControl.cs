using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyControl : MonoBehaviour
{

    float speed; //Enemy flyspeed

    void Start()
    {
        speed = 1f; //Setting enemy flyspeed  
    }

    
    void Update()
    {
        //Get the enemy current position
        Vector3 position = transform.position;

        //Compute the enemy new position
        position = new Vector3 (position.x, position.y - speed * Time.deltaTime, position.z = -6);

        //Update the enemy position
        transform.position = position;

		//If the enemy went outside the screen on the bottom, then destroy the enemy
		if (transform.position.y < -2.28)
		{
			Destroy(gameObject);
		}
	}
}
