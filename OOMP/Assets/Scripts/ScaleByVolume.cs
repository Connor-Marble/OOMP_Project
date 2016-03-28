using UnityEngine;
using System.Collections;

public class ScaleByVolume : MonoBehaviour {
	private MusicListener listener;

	private float startY;

	[SerializeField]
	private float scalingFactor = 1f;
	// Use this for initialization
	void Start () {
		startY = transform.position.y;
		listener = FindObjectOfType<MusicListener> ();
		listener.GetVolume += scale;
	}

	void scale(float value){
		transform.localScale = new Vector3 (transform.localScale.x, value*scalingFactor, transform.localScale.z);

	}
}
