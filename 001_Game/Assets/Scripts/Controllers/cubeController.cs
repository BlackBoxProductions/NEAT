using UnityEngine;
using System.Collections;

public class cubeController : MonoBehaviour 
{

    GameManager GM;

	// Use this for initialization
	void Start () 
    {
        GM = GameManager.Instance;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!GM.paused)
            this.transform.Translate(0, 1, 0, Space.World);
	}
}
