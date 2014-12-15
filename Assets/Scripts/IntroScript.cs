using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour {

	public AudioSource hitSound;
	public float hitSoundPlayDelay = 2.0f;

	// Use this for initialization
	void Start () {
		hitSound.PlayDelayed(hitSoundPlayDelay);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKey){
			Application.LoadLevel (1);
		}
	}
}
