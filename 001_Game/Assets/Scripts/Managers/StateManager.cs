using UnityEngine;
using System.Collections;

/**
 * Author:          Ingo Mayer
 * Date:            09.04.2015
 * 
 * Last modified:   27.05.2015
 * 
 * Purpose:         Contains state logic and handles global state changes 
 **/ 

public class StateManager : MonoBehaviour 
{
    GameManager GM;
    Logger log;


    private void loadSceneByName(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
        GM = GameManager.Instance;
        GM.onStateChange += HandleOnStateChange;
        log = Logger.Instance;
    }

    public void HandleOnStateChange()
    {
        log.info("Game state changed to:" + GM.gameState);

        // only change scene if the new state indicates a scene change (scene prefix in name)
        if ( GM.gameState.ToString().Contains("scene") )
            loadSceneByName( GM.gameState.ToString() );

        // pause game state change
        if (GM.gameState.ToString().CompareTo("state_Paused") == 0)
            pauseGame();

        if (GM.gameState.ToString().CompareTo("state_Idle") == 0)
        {
            unpauseGame();
        }
    }

    private void pauseGame()
    {
        Debug.Log("pausing game");
        GM.paused = true;
    }

    private void unpauseGame()
    {
        Debug.Log("resuming game");
        GM.paused = false;
    }

}
