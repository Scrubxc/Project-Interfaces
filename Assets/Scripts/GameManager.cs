using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    //Reference to our game objects
    public GameObject playButton;
    public Player playerShip;
    public EnemySpawner enemySpawner;
    public GameObject GameOverGO;
    public GameScore gameScore; // Reference to the score text UI game object
    //public GameObject scoreVisible;
    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }

    GameManagerState GmState;
    void Start()
    {
        GmState = GameManagerState.Opening;

      
    }


    //Function to update the game manager state
    void UpdateGameManagerState()
    {

        switch(GmState)
        {
            case GameManagerState.Opening:
                //Set play button visible (active)
                playButton.SetActive(true);

                break;
            case GameManagerState.Gameplay:
                //Reset the score
                //gameScore.GetComponent<GameScore>().Score = 0;
                gameScore.ResetScore();

                //Hide play button
                playButton.SetActive(false);

                //set the player visible (active)
                playerShip.GetComponent<Player>().Init();

				//Hide game over
				GameOverGO.SetActive(false);

                //Hide score
                gameScore.Hide();

				//Start enemy spawner
				enemySpawner.ScheduleEnemySpawner();

                break;
            case GameManagerState.GameOver:
                //Stop enemy spawner
                enemySpawner.UnscheduleEnemySpawner();

                //Display game over
                GameOverGO.SetActive(true);

                //Show score
                gameScore.Show();

				//Change game manager state to Opening state after 7 seconds
				Invoke("ChangeToOpeningState", 7f);

                break;
        }
    }
    //Function to set the game manager state
    public void SetGameManagerState(GameManagerState state)
    {
        GmState = state;
        UpdateGameManagerState();
    }

    //Our player button will call this function when the user clicks the button
    public void StartGameplay()
    {
        GmState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    //Function to change game manager state to opening state
    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }

    //Implement ChangeToBossState();
}
