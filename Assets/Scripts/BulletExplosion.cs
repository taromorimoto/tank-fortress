using UnityEngine;
using System.Collections;

public class BulletExplosion : MonoBehaviour {

	public AudioClip[] explosions;
	AudioSource aud;
	
	// Use this for initialization
	void Start () {
		int i = Random.Range(0, explosions.Length);
		aud = (AudioSource)gameObject.GetComponent<AudioSource>();
		aud.clip = explosions[i];
		aud.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
