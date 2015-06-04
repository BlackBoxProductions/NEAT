using UnityEngine;
using System.Collections;

/**
 * Author: Ingo Mayer
 * Date:   20.05.2015
 * 
 * Purpose: Basic Menu class - inherit from this to implement UI functionality
 **/ 

public class Menu : MonoBehaviour 
{

    protected GameManager GM;

    // Use this for initialization
    void Awake()
    {
        GM = GameManager.Instance;
        GM.onStateChange += HandleOnStateChange;
    }

    public void HandleOnStateChange() { }



	
}
