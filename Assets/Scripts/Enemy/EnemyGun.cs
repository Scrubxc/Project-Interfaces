using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{

    public GameObject EnemyBulletGO; //Getting enemy bullet prefab

    void Start()
    {
        //fire an enemy bullet after 1 second
        Invoke("FireEnemyBullet", 1f);
    }

    
    void Update()
    {
        
    }

    //Function to fire an enemy bullet
    void FireEnemyBullet()
    {
        //Get a reference to the player's ship
        GameObject playerShip = GameObject.Find("Player");

        if(playerShip != null) //if the player is not dead
        {
            //instantiate an enemy bullet
            GameObject bullet = (GameObject)Instantiate(EnemyBulletGO);

            //set the bullet's initial position
            bullet.transform.position = transform.position;

            //compute the bullet's direction towards the player's ship
            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            //Set the bullet's direction
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}

