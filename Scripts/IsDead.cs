using UnityEngine;
using System.Collections;

public class IsDead : MonoBehaviour
{
	void Start ()
	{
	
	}

	void Update ()
	{
		if(transform.position.y < -25)
		{
			Application.LoadLevel("GameOver");
		}
	}
}
