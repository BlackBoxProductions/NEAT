using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * Author: Ingo Mayer
 * Date:   20.05.2015
 * 
 * Purpose: Provide UI functionality for the options menu
 **/ 

public class OptionsMenuController : Menu 
{
    public GameObject prefab;
    
    ///<summary>
    /// Use this to return to the main menu without saving
    ///</summary>
    public void ClickedDiscardButton()
    {
        Canvas canvas = GetComponent<Canvas>();

        Instantiate(prefab);
    }

    public void returnToMainMenu()
    {
        GM.SetGameState(gameStates.scene_MainMenu);       
    }

    public void stayInMenu()
    {
        DestroyObject(GameObject.FindGameObjectWithTag("PopupMenu"));
    }

    public void returnToPauseMenu()
    {
        Debug.Log("No Pause Menu Exists yet");
    }

    ///<summary>
    /// Use this to return to the pause menu without saving
    ///</summary>
    public void ClickedDiscardButtonInPauseOptions()
    {
    }

    public void ClickedSaveButtonInMainOptions()
    {

    }
    

}
