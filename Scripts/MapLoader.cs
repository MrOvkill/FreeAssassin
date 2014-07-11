using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class MapLoader : MonoBehaviour
{
	public GameObject typePlayer;
	public GameObject typeTile;
	public GameObject typeLight;
	public GameObject dudeboy;

	private int npcnum;

	private AIWorld world;

	void Start ()
	{
		string text;
		if(File.Exists("map.txt"))
		{
			text = File.ReadAllText("map.txt");
		}
		else
		{
			StreamWriter sw = File.CreateText("map.txt");
			sw.WriteLine ("Player 0 2 0");
			sw.WriteLine ("Tile 0 0 0 10 1 10");
			sw.WriteLine ("Light 0 5 0");
			sw.WriteLine ("Tile 0 6 0 10 1 10");
			sw.Close();
			text = File.ReadAllText("map.txt");
		}

		string[] lines = text.Split("\n".ToCharArray());

		foreach(string line in lines)
		{
			parseLine (line);
		}
	}

	public void parseLine(string line)
	{
		string[] args = line.Split(' ');
		if(line.StartsWith("Player"))
		{
			Vector3 pos = new Vector3(Convert.ToSingle(args[1]), Convert.ToSingle(args[2]), Convert.ToSingle(args[3]));
			Instantiate(typePlayer, pos, Quaternion.identity);
		}
		if(line.StartsWith("Tile"))
		{
			Vector3 pos = new Vector3(Convert.ToSingle(args[1]), Convert.ToSingle(args[2]), Convert.ToSingle(args[3]));
			Vector3 scale = new Vector3(Convert.ToSingle(args[4]), Convert.ToSingle(args[5]), Convert.ToSingle(args[6]));
			GameObject g = (GameObject)Instantiate(typeTile, pos, Quaternion.identity);
			g.transform.localScale = scale;
		}
		if(line.StartsWith("Light"))
		{
			Vector3 pos = new Vector3(Convert.ToSingle(args[1]), Convert.ToSingle(args[2]), Convert.ToSingle(args[3]));
			Instantiate(typeLight, pos, Quaternion.identity);
		}
		if(line.StartsWith("AIWorld"))
		{
			Vector3 firstBound = new Vector3(Convert.ToSingle(args[1]), Convert.ToSingle(args[2]), Convert.ToSingle(args[3]));
			Vector3 secondBound = new Vector3(Convert.ToSingle(args[4]), Convert.ToSingle(args[5]), Convert.ToSingle(args[6]));
			Vector3 thirdBound = new Vector3(Convert.ToSingle(args[7]), Convert.ToSingle(args[8]), Convert.ToSingle(args[9]));
			Vector3 fourthBound = new Vector3(Convert.ToSingle(args[10]), Convert.ToSingle(args[11]), Convert.ToSingle(args[12]));
			AIWorld nworld = new AIWorld(firstBound, secondBound, thirdBound, fourthBound, dudeboy);
			if(nworld != null)
			{
				world = nworld;
			}
			else
			{
				Debug.Log ("AIWorld was null!");
			}
		}
		if(line.StartsWith("AISpawn"))
		{
			Vector3 firstBound = new Vector3(Convert.ToSingle(args[1]), Convert.ToSingle(args[2]), Convert.ToSingle(args[3]));
			Vector3 secondBound = new Vector3(Convert.ToSingle(args[4]), Convert.ToSingle(args[5]), Convert.ToSingle(args[6]));
			Vector3 thirdBound = new Vector3(Convert.ToSingle(args[7]), Convert.ToSingle(args[8]), Convert.ToSingle(args[9]));
			Vector3 fourthBound = new Vector3(Convert.ToSingle(args[10]), Convert.ToSingle(args[11]), Convert.ToSingle(args[12]));
			int amount = Convert.ToInt32(args[13]);
			if(world != null)
			{
				world.addZone(firstBound, secondBound, thirdBound, fourthBound, amount);
			}
			else
			{
				Debug.Log ("AIWorld was null!");
			}
		}
		if(line.StartsWith("#"))
		{
			return;
		}
	}

	void Update()
	{
		npcnum = 0;
		world.Update ();
		npcnum = AIWorld.NPCS.Count;
		if(npcnum <= 0)
		{
			Application.LoadLevel("Victory");
		}
	}

	void OnGUI()
	{
		GUI.Box(new Rect(10,40,75,20), "NPCS: " + npcnum);
	}
}