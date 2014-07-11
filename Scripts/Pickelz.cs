using UnityEngine;
using System.Collections;

public class Pickelz : MonoBehaviour {

	public GameObject gore;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
		if(Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			if(Physics.Raycast(transform.position, transform.forward, out hit, 5))
			{
				GameObject g = hit.transform.gameObject;
				if(hit.collider.gameObject.name.StartsWith("Dudeboy"))
				{
					for(int i = 0; i < AIWorld.NPCS.Count; i++)
					{
						if(g.transform.position == ((AI)AIWorld.NPCS[i]).obj.transform.position)
						{
							AI ai = ((AI)AIWorld.NPCS[i]);
							Vector3 AIPOS = ai.obj.transform.position;
							ai.destroy();
							GameObject go = (GameObject)GameObject.Instantiate(gore);
							go.transform.position = AIPOS;
						}
					}
					for(int i = 0; i < AIWorld.NPCS.Count; i++)
					{
						AI ai = ((AI)AIWorld.NPCS[i]);
						ai.hostile = true;
						AIWorld.NPCS[i] = ai;
					}
				}
			}
		}
	}
}
