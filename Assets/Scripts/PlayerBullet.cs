using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBullet : MonoBehaviour
{
    float speed;

    void Start()
    {
        speed = 0.5f;
    }

    
    void Update()
    {
        //Get the bullet's current position
        Vector2 position = transform.position;

        //Compute the bullet's new position
        position = new Vector2 (position.x, position.y + speed * Time.deltaTime);

        //Update the bullet's position
        transform.position = position;

        //This is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2(1, 1));

        //If the bullet went outside the screen at the top, then destroy the bullet
        if(transform.position.y > max.y)
        {
            Destroy(gameObject);
        }    
    }
}
