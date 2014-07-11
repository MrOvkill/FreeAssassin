using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class Hitpoints : MonoBehaviour
{
	public int hitpoints;
	Stopwatch sw;
	long last;
	// Use this for initialization
	void Start ()
	{
		sw = new Stopwatch();
		if ( hitpoints <= 0)
		{
			hitpoints = 1;
		}
		last = sw.ElapsedMilliseconds;
	}

	public void hit (int damage)
	{
		hitpoints -= damage;
		last = sw.ElapsedMilliseconds;
	}

	void OnGUI()
	{
		GUI.Box(new Rect(10,10,62,20), "HP: " + hitpoints);
	}

	// Update is called once per frame
	void Update ()
	{
		if ( hitpoints < 0)
		{
			if(gameObject.name.StartsWith("Player"))
			{
				Application.LoadLevel("GameOver");
			}
			else
			{
				GameObject.Destroy(gameObject);
			}
		}
	}
}
