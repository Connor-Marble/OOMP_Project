using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {

    ParticleSystem system;
    public Instrument instrument;
	// Use this for initialization
	void Start () {
	    system = GetComponent<ParticleSystem>();
        instrument.beatPlayed+=system.Play;
	}
	
}
