using UnityEngine;
using System.Collections;

public class UIBlock : MonoBehaviour {
	[SerializeField]
	private Material inactive;

	[SerializeField]
	private Material active;

	private Renderer render;

	InstrumentModifier modifier;

	// Use this for initialization
	void Start () {
		render = GetComponent<Renderer> ();
		render.material = inactive;
		modifier = GetComponent<InstrumentModifier> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(){
		render.material = active;
		if (modifier != null) {
			modifier.setVals();
		}
	}

	void OnCollisionExit(){
		render.material = inactive;
	}
}
