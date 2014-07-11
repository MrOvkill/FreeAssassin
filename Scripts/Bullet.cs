using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
	
	}

	void OnCollisionEnter(Collision c)
	{
		if(c.gameObject.name.StartsWith("Player"))
		{
			GameObject.Find("Player(Clone)").GetComponent<Hitpoints>().hit (1);
		}
		if(c.gameObject.name.StartsWith("Dudeboy"))
		{
			Destroy(c.gameObject);
		}
		Destroy (gameObject);
	}

	void Update ()
	{
		
	}
}