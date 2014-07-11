using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Got it to exit when I press a key.
	void Update ()
	{
		if(Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
