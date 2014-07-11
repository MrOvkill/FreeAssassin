using UnityEngine;
using System.Collections;

public class GoreDelete : MonoBehaviour {

	public int maxTime;

	private int time;

	// Use this for initialization
	void Start ()
	{
		time = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		time++;
		if(time >= maxTime)
		{
			GameObject.Destroy(gameObject);
		}
	}
}
