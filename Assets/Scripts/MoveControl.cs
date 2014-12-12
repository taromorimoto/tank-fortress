using UnityEngine;
using System.Collections;

public class MoveControl : MonoBehaviour {
	public float turnSpeed = 100.0f;
	public float driveSpeed = 100.0f;
	public float nitroForce = 500000.0f;
	
	public AudioSource nitroAudio;
	public AudioSource moveAudio;
	public float moveAudioFadeSpeed = 3.0f;
	public float moveAudioFade = 0.0f;
	
	float turn = 0;
	float drive = 0;
	CannonController cannon;
	
	void Start() {
		cannon = gameObject.GetComponentInChildren<CannonController>();
	}
	
	public void UseNitro() {
		rigidbody.AddForce(transform.forward * nitroForce * cannon.energySlider.value, ForceMode.Impulse);
		print(gameObject.name + " UseNitro!");
		nitroAudio.Play();
	}
	
	public void SetTurn(float direction) {
		turn = turnSpeed * direction;
		//print(gameObject.name + " SetTurn: " + turn);
	}
	
	public void SetDrive(float direction) {
		drive = driveSpeed * direction;
		//print(gameObject.name + " SetDrive: " + drive);
	}
	
	void UpdateMoveAudio() {
		bool play = turn != 0 || drive != 0;
		if (play) {
			moveAudioFade = Mathf.Lerp(moveAudioFade, 1.0f, moveAudioFadeSpeed * Time.deltaTime);
		} else {
			moveAudioFade = Mathf.Lerp(moveAudioFade, 0.0f, moveAudioFadeSpeed * Time.deltaTime);
		}
		
		if (moveAudio.isPlaying && !play && moveAudioFade < 0.05f) {
			moveAudio.Stop();
			print ("Audio Stop");
		}
		if (!moveAudio.isPlaying && play) {
			moveAudio.Play();
			print ("Audio Start");
		}
		
		if (moveAudio.isPlaying) {
			moveAudio.volume = moveAudioFade;
			moveAudio.pitch = moveAudioFade;
		}
	}
	
	void Update() {
		UpdateMoveAudio();
		
		if (turn != 0.0f) {
			transform.RotateAround(transform.position, transform.up, turn * Time.deltaTime);
		}
	}
	
	void FixedUpdate() {
		if (drive != 0.0f) {
			rigidbody.AddForce(transform.forward * drive, ForceMode.Force);
		}
	}
}




