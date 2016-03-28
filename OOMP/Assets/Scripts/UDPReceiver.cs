using UnityEngine;
using System.Collections;
using System.Threading;
using System.Net.Sockets;
using System.Net;

public class UDPReceiver : MonoBehaviour {

	public Vector3 Hand1;
	public Vector3 Hand2;

	int port = 55558;

	int messageLen = 24;

	Thread thread;

	bool flipEndiness = true;

	UdpClient client;

	// Use this for initialization
	void Start () {
		thread = new Thread(new ThreadStart(ReceiveData));
		thread.IsBackground = false;
		thread.Start ();
	}

	void ReceiveData(){
		Debug.Log ("Thread Started");
		IPEndPoint inAddrAny = new IPEndPoint(IPAddress.Any, 0);
		client = new UdpClient (port);

		int byteCount = 0;

		byte[] newestValidMessage = new byte[messageLen];

		while (true) {
			byte[] received = client.Receive(ref inAddrAny);
			Debug.Log("Got " + received.Length + " bytes");
			if(received.Length>=messageLen-byteCount){
				//there is enough new information to complete an update
				int bytesLeft = messageLen-byteCount;
				if(received.Length-bytesLeft>messageLen){
					//entirely new message contained in latest receive
					int remainder = (received.Length-bytesLeft)%messageLen;

					for(int i = received.Length-1-remainder;i>received.Length-1-remainder-messageLen;i--){
						newestValidMessage[i%messageLen] = received[i];
					}

					UpdateHands(newestValidMessage);

					for(int i =received.Length-1-remainder;i<received.Length;i++){
						newestValidMessage[i-received.Length+1+remainder] = received[i];
					}

				}
				else{
					for(int i=byteCount;i<messageLen;i++){
						newestValidMessage[i] = received[i-byteCount];
					}
					UpdateHands(newestValidMessage);
					for(int i=messageLen;i<received.Length;i++){
						newestValidMessage[i-messageLen] = received[i];
					}
					byteCount = (byteCount+received.Length)%messageLen;
				}
			}

			else{
				//there is not enough information to complete an update
				for(int i=byteCount;i<messageLen;i++){
					newestValidMessage[i] = received[i-byteCount];
				}
				byteCount+=received.Length;
			}

		}

	}

	void UpdateHands(byte[] message){
		if (flipEndiness) {
			for (int i=0; i<messageLen; i+=4) {
				byte tmp = message[i];
				message[i] = message[i+3];
				message[i+3] = tmp;

				tmp = message[i+1];
				message[i+1] = message[i+2];
				message[i+2] = tmp;
			}
		}

		Hand1 = new Vector3(System.BitConverter.ToSingle (message, 0),
		                    System.BitConverter.ToSingle (message, 4),
		                    System.BitConverter.ToSingle (message, 8));

		Hand2 = new Vector3(System.BitConverter.ToSingle (message, 12),
		                    System.BitConverter.ToSingle (message, 16),
		                    System.BitConverter.ToSingle (message, 20));
	}

	void OnApplicationQuit(){
		Debug.Log("ending");
		thread.Abort ();
		client.Close ();
	}
}
