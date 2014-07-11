using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {
	private int mode;

	// Use this for initialization
	void Start ()
	{
		mode = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 pos = transform.position;
		if(pos.y < 1.75f)
		{
			mode = 1;
		}
		if(pos.y > 2.25f)
		{
			mode = 0;
		}
		if(mode == 1)
		{
			pos.y+= 0.01f;
		}
		else
		{
			pos.y-= 0.01f;
		}
		transform.position = pos;
	}
}
