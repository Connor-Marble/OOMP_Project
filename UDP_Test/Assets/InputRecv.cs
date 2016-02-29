using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Net;
using System.Net.Sockets;

public class InputRecv : MonoBehaviour {
	private bool started;

	[SerializeField]
	MessageText msgTxt;

	[SerializeField]
	private InputField portIn, addrIn;

	private string address;
	
	UdpClient client;

	IPEndPoint inAddrAny = new IPEndPoint(IPAddress.Any, 0);

	private int x, y;

	// Use this for initialization
	void Start () {
		Screen.sleepTimeout = (int)SleepTimeout.NeverSleep;
		StartRecv();
		x = 50;
		y = 50;
	}

	void StartRecv(){
		address = addrIn.text;
		int port = int.Parse (portIn.text);
		started = true;
		client = new UdpClient (port);

	}

	// Update is called once per frame
	void Update () {
		if (started && client.Available>0) {
			Debug.Log("Receiving");
			byte[] recieved = client.Receive(ref inAddrAny);
			string msg = System.Text.Encoding.Default.GetString(recieved);
			msgTxt.UpdateText(msg);
			string[] coordStrings = msg.Split(':');

			x = System.Int32.Parse(coordStrings[0]);
			y = System.Int32.Parse(coordStrings[1]);
		}

	}

	void OnGUI(){
		GUI.Box (new Rect(x-1, y-1, x+1, y+1), "O");
	}
}
