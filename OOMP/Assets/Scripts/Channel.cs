using UnityEngine;
using System.Collections;

public class Channel : MonoBehaviour {
    [SerializeField]
    private Instrument[] instruments;
    
    [SerializeField]
    private float speed = 1f;
    
    [SerializeField]
    private float volume = 0.5f;
    
    private float[] volumeStarts;
    private float[] speedStarts;
    
	// Use this for initialization
	void Start () {
	    volumeStarts = new float[instruments.Length];
        speedStarts = new float[instruments.Length];
        
        NormalizeVolume();
        for(int i=0;i<speedStarts.Length;i++){
            speedStarts[i] = instruments[i].getSpeed();
        }
        
        
	}
	
    void NormalizeVolume(){
        float maxVol = 0f;
        foreach(Instrument instrument in instruments){
            maxVol = Mathf.Max(instrument.getVolume(), maxVol);
        }
        
        if(maxVol<=0f)
            return;
            
        for(int i=0;i<instruments.Length;i++){
            instruments[i].setVolume(instruments[i].getVolume()/maxVol);
            volumeStarts[i] = instruments[i].getVolume();
        }
    }
    
	// Update is called once per frame
	void Update () {
        volume = Mathf.Clamp(volume, 0f, 1f);
	    UpdateInstruments();
	}
    
    void UpdateInstruments(){
        for(int i=0;i<instruments.Length;i++){
            instruments[i].setVolume(volume*volumeStarts[i]);
            instruments[i].setSpeed(speed*speedStarts[i]);
        }
    }
}
