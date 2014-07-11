using UnityEngine;
using System.Collections;

public class Gore : MonoBehaviour
{
	public GameObject chunk;

	public int amount;

	// Use this for initialization
	void Start ()
	{
		for(int i = 0; i < amount; i++)
		{
			GameObject g = (GameObject)Instantiate(chunk, new Vector3(transform.position.x+Random.Range(-1, 1), transform.position.y+Random.Range(-1, 1), transform.position.z+Random.Range(-1, 1)), Quaternion.identity);
			g.rigidbody.AddForce(new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5)));
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
