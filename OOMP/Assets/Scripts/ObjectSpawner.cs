using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {
	[SerializeField]
	GameObject toSpawn;

	[SerializeField]
	private Instrument instrument;
	// Use this for initialization
	void Start () {
		instrument.beatPlayed += Spawn;
	}

	void Spawn(){
		Instantiate (toSpawn, transform.position, Quaternion.identity);
	}
}
