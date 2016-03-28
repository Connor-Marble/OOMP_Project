using UnityEngine;
using System.Collections;

public class Instrument : MonoBehaviour {
    
    public delegate void BeatDelegate();
    public BeatDelegate beatPlayed;
    
    public AudioSource sound;

    [SerializeField]
    private float patternLen;

    [SerializeField]
    private float[] beats;

    [SerializeField]
    private float volume = 0.5f;

    [SerializeField]
    private float speed = 1f;

    private int nextBeat = 0;
    
	// Use this for initialization
	void Start () {
         sound = GetComponent<AudioSource>();
         beatPlayed+=PlayBeat;
	}
	
	// Update is called once per frame
	void Update () {
         float time = (Time.timeSinceLevelLoad*speed)%patternLen;
	     float timeLeft = time - beats[nextBeat];
         if(timeLeft>0 && timeLeft<Time.deltaTime*speed){
                beatPlayed();
         }
         sound.volume = volume;
	}

    void PlayBeat(){
		//sound.PlayOneShot (sound.clip);
		sound.Play ();
         nextBeat = (nextBeat+1)%beats.Length;
    }
    
    public float getVolume(){return volume;}
    public void setVolume(float volume){this.volume = volume;}
    
    public float getSpeed(){return speed;}
    public void setSpeed(float speed){this.speed = speed;}
}
