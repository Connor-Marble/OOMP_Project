/************************************************************/
/* Author: Connor Marble 
/* Creation Date: March 18, 2016 
/* Due Date: April 18, 2016 
/* Course: CSC 220 
/* Professor Name: Dr. Parson
/* Assignment: Term Project 
/* Filename: UIBlock.cs 
/* Purpose: This script controls the blocks which form the
/*3D UI used to control the music
/************************************************************/


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


	[SerializeField]
	bool rotated = false;

	void Start (){
		receiver = FindObjectOfType<UDPReceiver> ();
	}

	// Update is called once per frame
	void Update () {
		if (!rotated) {
			handOne.transform.position = origin + new Vector3 (receiver.Hand1.x * scale.x, receiver.Hand1.y * scale.y, receiver.Hand1.z * scale.z);
			handTwo.transform.position = origin + new Vector3 (receiver.Hand2.x * scale.x, receiver.Hand2.y * scale.y, receiver.Hand2.z * scale.z);
		} else {
			handOne.transform.position = origin + new Vector3 (receiver.Hand1.z * scale.z, receiver.Hand1.y * scale.y, receiver.Hand1.x * scale.x);
			handTwo.transform.position = origin + new Vector3 (receiver.Hand2.z * scale.z, receiver.Hand2.y * scale.y, receiver.Hand2.x * scale.x);
		}
	}
}
