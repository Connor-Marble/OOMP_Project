using UnityEngine;
using System.Collections;

public class TerrainObject : MonoBehaviour {
	private GameManager manager;
	float speed;
	// Use this for initialization
	void Start () {
		manager = FindObjectOfType<GameManager> ();
		speed = manager.terrainSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.right * speed*Time.deltaTime;
		if (transform.position.x > manager.killX) {
			Destroy(this.gameObject);
		}
	}
}
