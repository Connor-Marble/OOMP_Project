using UnityEngine;
using System.Collections;

public class MusicListener : MonoBehaviour {

	[SerializeField]
	private float dbRef = 0f;

	Instrument[] instruments;
	AudioSource[] sources;

	public delegate void SpectrumTotalDelegate(float[] spectrum);
	public delegate void VolumeDelegate(float vol);

	public VolumeDelegate GetVolume;
	public SpectrumTotalDelegate GetSpec;

	private int channels = 16;

	private int spectrumSize = 64;

	// Use this for initialization
	void Start () {
		instruments = FindObjectsOfType<Instrument> ();
		sources = FindObjectsOfType<AudioSource> ();



		//GetVolume += printVol;
	}

	void printVol(float value){
		Debug.Log (value);
	}

	// Update is called once per frame
	void Update () {
		if(GetVolume!=null)
			GetTotalVolume ();

		if (GetSpec != null)
			GetSpectrum ();
	}

	void GetSpectrum(){
		float[] spectrum = new float[spectrumSize];

		foreach(Instrument instrument in instruments){
			AudioSource source = instrument.sound;
			float[] partialSpectrum = new float[spectrumSize];
			source.GetSpectrumData(partialSpectrum, 0, FFTWindow.Blackman);

			for(int i=0;i<spectrumSize;i++){
				spectrum[i]+=partialSpectrum[i]*instrument.getVolume();
			}
		}
		GetSpec (spectrum);
	}

	void GetTotalVolume(){
		float totalVol = 0f;
	
		foreach(Instrument instrument in instruments){
			AudioSource source = instrument.sound;

			float[] pass = new float[channels];
			source.GetOutputData(pass, 0);
			float passTotal=0f;
			for(int i=0;i<channels;i++){
				passTotal+=Mathf.Abs(pass[i]);
			}

			totalVol+=(passTotal/channels)*instrument.getVolume();
		}
		//totalVol = Mathf.Log10 (totalVol / sources.Length) * 20;
		GetVolume (totalVol);
	}
}
