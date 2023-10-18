using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Reference to our game objects
    public GameObject playButton;
    public GameObject playerShip;

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

                break;
            case GameManagerState.Gameplay:

                break;
            case GameManagerState.GameOver:

                break;
        }
    }
    //Function to set the game manager state
    public void SetGameManagerState(GameManagerState state)
    {
        GmState = state;
        UpdateGameManagerState();
    }

}
