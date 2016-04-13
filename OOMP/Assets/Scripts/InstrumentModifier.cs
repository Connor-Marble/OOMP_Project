using UnityEngine;
using System.Collections;

public class InstrumentModifier : MonoBehaviour {

	[SerializeField]
	private Instrument instrument;

	[SerializeField]
	private float speed = 0f;

	[SerializeField]
	private float vol = 0f;

	public void setVals(){
		instrument.setSpeed (speed);
		instrument.setVolume (vol);
	}
}
