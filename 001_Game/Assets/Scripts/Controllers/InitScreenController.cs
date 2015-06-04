using UnityEngine;
using System.Collections;

public class InitScreenController : SceneController 
{
    private Logger log;
	// Use this for initialization
	void Start () 
    {
        Init();
        GM.SetGameState(gameStates.scene_MainMenu);
	}

    private void Init()
    {
        log = Logger.Instance;

        //TODO: Add initialization stuff
        log.info("Finished initialization.");
    }

}
