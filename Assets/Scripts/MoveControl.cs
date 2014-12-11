using UnityEngine;
using System.Collections;

public class MoveControl : MonoBehaviour {
	public float turnSpeed = 100.0f;
	public float driveSpeed = 100.0f;
	public float nitroForce = 500000.0f;
	
	float turn = 0;
	float drive = 0;
	
	public void UseNitro() {
		rigidbody.AddForce(transform.forward * nitroForce, ForceMode.Impulse);
		print(gameObject.name + " UseNitro!");
		
	}
	
	public void SetTurn(float direction) {
		turn = turnSpeed * direction;
		//print(gameObject.name + " SetTurn: " + turn);
	}
	
	public void SetDrive(float direction) {
		drive = driveSpeed * direction;
		//print(gameObject.name + " SetDrive: " + drive);
	}
	
	void Update() {
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




