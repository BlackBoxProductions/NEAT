using UnityEngine;
using System.Collections;

/**
 * Author: Ingo Mayer
 * Date:   09.04.2015
 * 
 * Purpose: Controls everything in a scene.
 *          Basic SceneController setup - inherit from this and add custom functionality
 *          for all specific scene controllers to avoid code duplication.
 **/

public class SceneController : MonoBehaviour 
{
    protected GameManager GM;

    protected void pauseGame()
    {
        Time.timeScale = 0f;
    }

	// Use this for initialization
	void Awake () 
    {
        GM = GameManager.Instance;
        GM.onStateChange += HandleOnStateChange;
	}

    public void HandleOnStateChange()
    {
    }


}
