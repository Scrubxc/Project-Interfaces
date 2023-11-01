using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyControl : MonoBehaviour
{
    GameObject scoreUITextGO; // Reference to the text UI gameObject

    public GameObject ExplosionGO; //Explosion Prefab

    float speed; //Enemy flyspeed

    void Start()
    {
        speed = 1f; //Setting enemy flyspeed  

        //Getting the score text UI
        scoreUITextGO = GameObject.FindGameObjectWithTag("ScoreTextTag");

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

	void OnTriggerEnter2D(Collider2D col)
	{
		//Detect collision of the enemy ship with the player ship, or with a player's bullet, or with a rocket/rocketExplosion
        if((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag") || (col.tag == "PlayerRocketTag"))
        {
            PlayExplosion();

			//Add 300 points to the score
			scoreUITextGO.GetComponent<GameScore>().Score += 300;

			Destroy(gameObject);
        }
	}

	/*void OnTriggerStay2D(Collider2D col)
	{
		//Detect if enemy ship is inside rocket collision and destroy it
        if(col.tag == "PlayerRocketTag")
        {
			PlayExplosion();

			//Add 300 points to the score
			scoreUITextGO.GetComponent<GameScore>().Score += 300;

			Debug.Log("hit");
			Destroy(gameObject);
		}
	}*/


	//Function to instantiate an explosion
	void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);

        //Set the position of the explosion
        explosion.transform.position = transform.position;
	}
}
