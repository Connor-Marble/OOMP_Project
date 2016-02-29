using UnityEngine;
using System.Collections;

public class TerrainObject : MonoBehaviour {

	float speed, end;

	// Use this for initialization
	void Start () {
		TerrainGenerator generator = FindObjectOfType<TerrainGenerator> ();
		speed = generator.getUpdateRate ();
		end = (float)generator.getLength ();
		transform.position = new Vector3 (generator.transform.position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.right * speed * Time.deltaTime;

		if (transform.position.x > end) {
			Destroy(this.gameObject);
		}
	}
}
