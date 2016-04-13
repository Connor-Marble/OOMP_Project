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

public class UIBlock : MonoBehaviour {

	//material used when block is not
	//being 'touched' by the user
	[SerializeField]
	private Material inactive;

	//material used when block is 'touched'
	[SerializeField]
	private Material active;

	[SerializeField]
	private Material enabled;

	//store reference to the block's renderer component
	private Renderer render;

	//modifier to apply on activation
	InstrumentModifier modifier;

	private UIBlock above, below, forward, back;

	//sets up the renderer, modifier and start material
	void Start () {
		render = GetComponent<Renderer> ();
		render.material = inactive;
		modifier = GetComponent<InstrumentModifier> ();

		//get adjacent UIBlocks
		above = GetAdjacent(Vector3.up);
		forward = GetAdjacent(Vector3.forward);
		back = GetAdjacent(Vector3.back);
		below = GetAdjacent(Vector3.down);
	}

	UIBlock GetAdjacent(Vector3 direction){
		RaycastHit hitInfo;
		if (Physics.Raycast (transform.position, direction, out hitInfo, 10f)) {
			return hitInfo.collider.gameObject.GetComponent<UIBlock>();
		}

		return null;
	}
	
	//The objects used to represent the user's hands are
	//rigidbodies, meaning this method is fired when they
	//move into the object this script is attached to. This
	//method will activate the modifier
	void OnCollisionEnter(){
		activate ();
		render.material = active;
		if (modifier != null) {
			modifier.setVals();
		}
	}

	//when the user's hand leaves, stop return to the non-activated color.
	void OnCollisionExit(){
		deactivate ();
	}

	public void deactivate(){
		render.material = inactive;
		if(above!=null)
			above.deactivate ();

		if(forward!=null)
			forward.deactivate ();
	}

	public void activate(){
		render.material = enabled;

		if(below!=null)
			below.deactivate();

		if(back!=null)
			back.deactivate();
	}
}
