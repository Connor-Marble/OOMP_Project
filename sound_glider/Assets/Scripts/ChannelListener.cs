using UnityEngine;
using System.Collections;

public class ChannelListener : MonoBehaviour {
	[SerializeField]
	private int channel;

	[SerializeField]
	private float threshold;

	public delegate void channelTrigger();

	public channelTrigger triggers;

	private TerrainGenerator generator;
	
	private bool activated;

	private float maxVal = 0f;

	// Use this for initialization
	void Start () {
		generator = FindObjectOfType<TerrainGenerator>();
		if (generator == null) {
			this.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		float value = generator.getChannel (channel);

		if (value > threshold*maxVal && !activated) {
			activated = true;
			triggers();
		}

		if (value < threshold*maxVal && activated) {
			activated = false;
		}

		if (value > maxVal) {
			maxVal = value;
		}

	}
}
