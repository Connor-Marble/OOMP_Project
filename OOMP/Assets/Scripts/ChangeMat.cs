using UnityEngine;
using System.Collections;

public class ChangeMat : MonoBehaviour {

	[SerializeField]
	private Color inactiveCol;

	[SerializeField]
	private Color activeCol;

	[SerializeField]
	private float fadeSpeed;

	[SerializeField]
	private Instrument instrument;

	private SpriteRenderer renderer;
	// Use this for initialization
	void Start () {
		renderer = GetComponent<SpriteRenderer> ();
		renderer.material.color = inactiveCol;
		instrument.beatPlayed += Activate;
	}
	
	// Update is called once per frame
	void Update () {
		renderer.material.color = Color.Lerp (renderer.material.color, inactiveCol, fadeSpeed);
	}

	void Activate(){
		renderer.material.color = activeCol;
	}
}
