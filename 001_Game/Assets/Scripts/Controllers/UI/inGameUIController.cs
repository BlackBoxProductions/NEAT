using UnityEngine;
using System.Collections;

public class inGameUIController : Menu 
{
    public GameObject popupMenu;

    public void clickedSideButton()
    {

        if(GM.gameState == gameStates.state_Paused)
        {
            DestroyObject(GameObject.FindGameObjectWithTag("PopupMenu"));
            GM.SetGameState(gameStates.state_Idle);
        }
        else
        {
            Instantiate(popupMenu);
            GM.SetGameState(gameStates.state_Paused);
        }
           
    }



}
