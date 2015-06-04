using UnityEngine;
using System.Collections;

public class QuitScreenController : SceneController 
{

	// Use this for initialization
	void Start () 
    {
       StartCoroutine( WaitCoroutine() ); 
	}

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(3);
        Application.Quit();
    }
}
