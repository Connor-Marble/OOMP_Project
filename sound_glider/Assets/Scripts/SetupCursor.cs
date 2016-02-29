using UnityEngine;
using System.Collections;

public class SetupCursor : MonoBehaviour {
	[SerializeField]
	private Texture2D cursorTex;
	// Use this for initialization
	void Start () {
		Cursor.SetCursor (cursorTex, Vector2.zero, CursorMode.Auto);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
