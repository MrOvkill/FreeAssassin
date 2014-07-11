using UnityEngine;
using System.Collections;

public class AIWorld
{
	public Vector3 bound1;
	public Vector3 bound2;
	public Vector3 bound3;
	public Vector3 bound4;

	public GameObject npc;

	public static ArrayList NPCS;

	public AIWorld (Vector3 b1, Vector3 b2, Vector3 b3, Vector3 b4, GameObject game)
	{
		bound1 = b1;
		bound2 = b2;
		bound3 = b3;
		bound4 = b4;
		npc = game;
		NPCS = new ArrayList();
	}

	public void addZone(Vector3 b1, Vector3 b2, Vector3 b3, Vector3 b4, int amount)
	{
		for(int i = 0; i < amount; i++)
		{
			GameObject g = (GameObject)GameObject.Instantiate(npc);
			g.transform.position = new Vector3(b1.x, b1.y, b1.z);
			NPCS.Add(new AI(g, b1, b2, b3, b4));
		}
	}

	public void Update ()
	{
		for(int i = 0; i < NPCS.Count; i++)
		{
			AI ai = ((AI)NPCS[i]);
			if(ai.destroyed)
			{
				NPCS.RemoveAt(i);
			}
			else
			{
				ai.update();
				NPCS[i] = ai;
			}
		}
	}
}
