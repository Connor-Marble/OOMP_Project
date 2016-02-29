using UnityEngine;
using System.Collections;

public class HudTarget : MonoBehaviour {
	[SerializeField]
	private Transform camera;
	
	[SerializeField]
	private float rate = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Camera.main.transform.position;
		Quaternion targetRot = Camera.main.transform.rotation;

		transform.rotation = targetRot;//Quaternion.Slerp(transform.rotation, targetRot, rate);


	}
}
