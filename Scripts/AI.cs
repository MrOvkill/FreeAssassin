using UnityEngine;
using System.Collections;

public class AI
{
	public GameObject obj;

	public Vector3 target;

	public bool destroyed, hostile;

	public Vector3 b1;
	public Vector3 b2;
	public Vector3 b3;
	public Vector3 b4;

	public AI(GameObject g, Vector3 bound1, Vector3 bound2, Vector3 bound3, Vector3 bound4)
	{
		b1 = bound1;
		b2 = bound2;
		b3 = bound3;
		b4 = bound4;
		obj = g;
		target = g.transform.position;
		destroyed = false;
	}

	public void newPos()
	{
		if(!destroyed)
		{
			if(!hostile)
			{
				Vector3 newPos = new Vector3 (0, 0, 0);
				newPos.x = Random.Range (b1.x, b2.x);
				newPos.y = b1.y;
				newPos.z = Random.Range (b2.z, b3.z);
				target = newPos;
			}
			else
			{
				if(GameObject.Find("Player(Clone)") != null)
				{
					obj.transform.LookAt(GameObject.Find("Player(Clone)").transform.position);
				}
			}
		}
	}

	public void update()
	{
		if(there())
		{
			newPos();
		}
		if(!destroyed)
		{
			Vector3 ppos = obj.transform.position;
			ppos.y = b1.y;
			obj.transform.position = ppos;
			if(!hostile)
			{
				obj.transform.LookAt(target);
				RaycastHit hit;
				if(!Physics.Raycast(obj.transform.position, obj.transform.forward, out hit, 1.5f))
				{
					obj.transform.position += obj.transform.forward*0.05f;
				}
				else
				{
					newPos();
				}
			}
			else
			{
				if(GameObject.Find("Player(Clone)") != null)
				{
					obj.transform.LookAt(GameObject.Find("Player(Clone)").transform.position);
				}
				RaycastHit hit;
				if(!Physics.Raycast(obj.transform.position, obj.transform.forward, out hit, 1.5f))
				{
					obj.transform.position += obj.transform.forward*0.05f;
				}
				else
				{
					if(hit.collider.gameObject.name.StartsWith("Player"))
					{
						GameObject.Find("Player(Clone)").GetComponent<Hitpoints>().hit (1);
					}
				}
			}
		}
	}

	public bool there()
	{
		if(!destroyed)
		{
			Vector3 pos = obj.transform.position;
			if((Mathf.Abs(pos.x-target.x) <= 1) && (Mathf.Abs(pos.z-target.z) <= 1))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else
		{
			return false;
		}
	}

	public void destroy()
	{
		destroyed = true;
		GameObject.Destroy (obj);
	}
}
