using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Reference to our game objects
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject GameOverGO;
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
                //Hide play button
                playButton.SetActive(false);

                //set the player visible (active)
                playerShip.GetComponent<Player>().Init();

				//Hide game over
				GameOverGO.SetActive(false);

				//Start enemy spawner
				enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();

                break;
            case GameManagerState.GameOver:
                //Stop enemy spawner
                enemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner();
                //Display game over
                GameOverGO.SetActive(true);

                //Change game manager state to Opening state after 8 seconds
                Invoke("ChangeToOpeningState", 8f);

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
