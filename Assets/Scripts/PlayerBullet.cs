using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBullet : MonoBehaviour
{
    float speed;

    void Start()
    {
        speed = 8f;
		//transform.position = new Vector3(transform.position.x, transform.position.y, -6);
	}

    
    void Update()
    {

		//Get the bullet's current position
		Vector3 position = transform.position;

        //Compute the bullet's new position
        position = new Vector3 (position.x, position.y + speed * Time.deltaTime, position.z = -6);

        //Update the bullet's position
        transform.position = position;

        //If the bullet went outside the screen at the top, then destroy the bullet
        if(transform.position.y > 3.4)
        {
            Destroy(gameObject);
        }    

    }
}
