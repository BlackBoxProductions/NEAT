/**
 * Author:          Ingo Mayer
 * Date:            23.03.2015
 * Name:            GameManager
 * 
 * Last modified:   27.05.2015
 * 
 * Purpose:         Basic GameManager class to be modified for different games
 *                  Uses Singleton pattern implementation with Monobehaviour -> creates new gameObject instance that will not be destroyed on scene change
 *          
 * HowTo:           Customize by editing the gameState enum and/or adding functions to the OnStateChangeHandler in other scripts
 **/


using UnityEngine;
using System.Collections;

// Game State Enum
public enum gameStates { state_Idle, state_Paused, state_ReceiveInput, state_ProcessInput, state_EnemyUpdate, state_EnvironmentUpdate, 
                         scene_Initialisation, scene_MainMenu, scene_QuitGame, scene_Test, scene_Options, scene_Trophies };

// Delegation to add event handlers
public delegate void OnStateChangeHandler();



public class GameManager : MonoBehaviour
{
    // global variables
    public bool paused = false;

    static GameManager instance = null;
    public gameStates gameState { get; private set; }
    public event OnStateChangeHandler onStateChange;
    protected GameManager() { }

    static public bool isActive
    {
        get
        {
            return instance != null;
        }
    }

    // Singleton with MonoBehaviour
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Object.FindObjectOfType(typeof(GameManager)) as GameManager;

                if (instance == null)
                {
                    // Create new game object for the manager
                    GameObject gameObj = new GameObject("gameManager");
                    DontDestroyOnLoad(gameObj);
                    instance = gameObj.AddComponent<GameManager>();
                }
            }

            return instance;
        }
    }

    // Setter
    public void SetGameState(gameStates gameState)
    {
        if (this.gameState.ToString().CompareTo(gameState.ToString()) != 0)
        {
            this.gameState = gameState;
            // trigger delegation to notify other scripts of state change
            if (onStateChange != null)
            {
                onStateChange();
            }
        }
    }
      
}
