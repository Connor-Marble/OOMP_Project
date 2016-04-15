using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
	
	[SerializeField]
	GameObject tree1, tree2, rock;
	GameObject spawnt;

	[SerializeField]
	private Instrument instrument;

	[SerializeField]
	private int spawner;

	void Start ()
	{
		instrument.beatPlayed += Spawn;
	}

	void Spawn ()
	{
		if (spawner == 0) {
			makeRandomness (tree2); // randomly places trees
		}
		if (spawner == 1) {
			makeRandomClouds (rock); // for hot air balloon
			makeTri (rock);			 // makes a triangle of rocks
		}
		if (spawner == 2) {
			makeCircle (tree1, rock); // makes a circle of tress with a rock in the middle
		}
		if (spawner == 3) {
			makeRandomClouds (rock); // for clouds
		}
		//another pattern => makeEx(objToSpawn);
	}

	void makeTri (GameObject objToSpawn)
	{
		Vector3 pos;
		float size;
		if (objToSpawn == rock)
			size = instrument.getVolume () * 3.5f;
		else
			size = instrument.getVolume () * 1.5f;
		int[,] coords = new int[,] {
			{ 0, 6 },
			{ 2, 3 },
			{ 4, -3 },
			{ 6, -6 },
			{ 2, -6 },
			{ -2, -6 },
			{ -6, -6 },
			{ -4, -3 },
			{ -2, 3 }
		};
		int randFactor = Random.Range (15, 100);
		for (int i = 0; i < coords.Length / 2; i++) {
			pos = new Vector3 (this.transform.position.x + coords [i, 0], this.transform.position.y + instrument.getVolume () * 3.5f, coords [i, 1] + randFactor);
			spawnt = Instantiate (objToSpawn, pos, Quaternion.identity) as GameObject;
			spawnt.transform.localScale = new Vector3 (size, size, size);
		}
	}

	void makeCircle (GameObject circleObj, GameObject middleObj)
	{
		Vector3 pos;
		float size = instrument.getVolume () * 1.5f;
		int[,] coords = new int[,] {
			{ -10, 0 },
			{ -6, 6 },
			{ 0, 10 },
			{ 6, 6 },
			{ 10, 0 },
			{ 6, -6 },
			{ 0, -10 },
			{ -6, -6 }
		};
		int randFactor = Random.Range (15, 100);
		for (int i = 0; i < coords.Length / 2; i++) {
			pos = new Vector3 (this.transform.position.x + coords [i, 0], this.transform.position.y, coords [i, 1] + randFactor);
			spawnt = Instantiate (circleObj, pos, Quaternion.identity) as GameObject;
			spawnt.transform.localScale = new Vector3 (size, size, size);
		}
		size *= 3;
		pos = new Vector3 (this.transform.position.x + 5, this.transform.position.y, randFactor + 15);
		spawnt = Instantiate (middleObj, pos, Quaternion.identity) as GameObject;
		spawnt.transform.localScale = new Vector3 (size, size, size);
	}

	void makeEx (GameObject objToSpawn) // threw in another pattern
	{
		Vector3 pos;
		float size;
		if (objToSpawn == rock)
			size = instrument.getVolume () * 3.5f;
		else
			size = instrument.getVolume () * 1.5f;
		int[,] coords = new int[,] {
			{ -6, 6 },
			{ -3, 3 },
			{ 0, 0 },
			{ 3, -3 },
			{ 6, -6 },
			{ 6, 6 },
			{ 3, 3 }, 
			{ -3, -3 }, 
			{ -6, -6 }
		};
		int randFactor = Random.Range (15, 100);
		for (int i = 0; i < coords.Length / 2; i++) {
			pos = new Vector3 (this.transform.position.x + coords [i, 0], this.transform.position.y, coords [i, 1] + randFactor);
			spawnt = Instantiate (objToSpawn, pos, Quaternion.identity) as GameObject;
			spawnt.transform.localScale = new Vector3 (size, size, size);
		}
	}

	void makeRandomness (GameObject objToSpawn)
	{
		Vector3 pos;
		float amnt = Mathf.Ceil (instrument.getVolume () * 15);
		float minZ, maxZ;
		float size = instrument.getVolume () * 2.5f;
		if (objToSpawn.name == "tree2")
			size *= 1.3f;
		for (int i = 0; i < amnt; i++) {
			minZ = 5;
			maxZ = 120;
			pos = new Vector3 (transform.position.x + Random.Range (0, 10), transform.position.y + (instrument.getVolume () * 2), Random.Range (minZ, maxZ)); 
			spawnt = Instantiate (objToSpawn, pos, Quaternion.identity) as GameObject;
			spawnt.transform.localScale = new Vector3 (size, size, size);
		}
	}

	void makeRandomClouds (GameObject objToSpawn) 	//can do either clouds or hot air balloon, if you have any luck importing them.
	{												//for testing purposes, I put in floating rocks.
		Vector3 pos;
		float minZ = 5, maxZ = 120;
		float size;
		if (objToSpawn == rock)
			size = instrument.getVolume () * 3.5f;
		else
			size = instrument.getVolume () * 1.5f;
		pos = new Vector3 (transform.position.x + Random.Range (0, 10), 40, Random.Range (minZ, maxZ)); 
		spawnt = Instantiate (objToSpawn, pos, Quaternion.identity) as GameObject;
		spawnt.transform.localScale = new Vector3 (size, size, size);
	}
}
