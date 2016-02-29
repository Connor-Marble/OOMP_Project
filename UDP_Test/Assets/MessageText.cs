using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class MessageText : MonoBehaviour {

	[SerializeField]
	private float fadeTime;

	private float lastUpdate;
	private Text messageDisp;

	[SerializeField]
	private Color start, end;

	// Use this for initialization
	void Start () {
		messageDisp = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		messageDisp.color = Color.Lerp (start, end, (Time.timeSinceLevelLoad - lastUpdate) / fadeTime + 0.001f);
	}

	public void UpdateText(string text){
		Debug.Log("Received: " + text);
		messageDisp.text = text;
		lastUpdate = Time.timeSinceLevelLoad;
	}
}
