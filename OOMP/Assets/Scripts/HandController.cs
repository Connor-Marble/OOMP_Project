using UnityEngine;
using System.Collections;

public class HandController : MonoBehaviour {
	[SerializeField]
	private GameObject handOne;

	[SerializeField]
	private GameObject handTwo;

	[SerializeField]
	private Vector3 origin = Vector3.zero;

	[SerializeField]
	private Vector3 scale = Vector3.one;

	private UDPReceiver receiver;

	void Start (){
		receiver = FindObjectOfType<UDPReceiver> ();
	}

	// Update is called once per frame
	void Update () {
		handOne.transform.position = origin + new Vector3(receiver.Hand1.x * scale.x, receiver.Hand1.y * scale.y, receiver.Hand1.z * scale.z);
		handTwo.transform.position = origin + new Vector3(receiver.Hand2.x * scale.x, receiver.Hand2.y * scale.y, receiver.Hand2.z * scale.z);
	}
}
