using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public float terrainSpeed;
	public float killX;
	// Use this for initialization
	void Start () {
		TerrainGenerator generator = FindObjectOfType<TerrainGenerator> ();
		terrainSpeed = generator.getUpdateRate();
		killX = generator.getLength() + generator.gameObject.transform.position.x + 20f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
