using UnityEngine;
using System.Collections;

/**
 * Author: Ingo Mayer
 * Date:   20.05.2015
 * 
 * Purpose: Provide UI functionality for the main menu
 **/ 

public class MainMenuUIController : MonoBehaviour 
{
    public GameManager GM;

    // Use this for initialization
    void Awake()
    {
        GM = GameManager.Instance;
        GM.onStateChange += HandleOnStateChange;
    }

    public void HandleOnStateChange() { }
    
    public void ClickedStartButton()
    {
        GM.SetGameState(gameStates.scene_Test);
    }

    public void ClickedExitButton()
    {
        GM.SetGameState(gameStates.scene_QuitGame);
    }

    public void ClickedOptionsButton()
    {
        GM.SetGameState(gameStates.scene_Options);
    }

    public void ClickedTrophiesButton()
    {
        GM.SetGameState(gameStates.scene_Trophies);
    }

    public void DebugReturnToMainMenu()
    {
        GM.SetGameState(gameStates.scene_MainMenu);
    }
}
