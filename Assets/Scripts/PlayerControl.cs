using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public KeyCode fireCannon = KeyCode.RightAlt;
	public KeyCode accelerate = KeyCode.UpArrow;
	public KeyCode reverse = KeyCode.DownArrow;
	public KeyCode turnLeft = KeyCode.LeftArrow;
	public KeyCode turnRight = KeyCode.RightArrow;
	
	void Update() {
		if (Input.GetKeyDown(fireCannon)) {
			gameObject.BroadcastMessage("ChargeCannon");
		}
		if (Input.GetKeyUp(fireCannon)) {
			gameObject.BroadcastMessage("FireCannon");
		}
		
		if (Input.GetKey(accelerate)) {
			gameObject.BroadcastMessage("SetDrive", 1);
		}
		if (Input.GetKey(reverse)) {
			gameObject.BroadcastMessage("SetDrive", -1);
		}
		if (Input.GetKey(turnLeft)) {
			gameObject.BroadcastMessage("SetTurn", -1);
		}
		if (Input.GetKey(turnRight)) {
			gameObject.BroadcastMessage("SetTurn", 1);
		}
		
		if (Input.GetKeyUp(accelerate)) {
			gameObject.BroadcastMessage("SetDrive", 0.0f);
		}
		if (Input.GetKeyUp(reverse)) {
			gameObject.BroadcastMessage("SetDrive", 0.0f);
		}
		if (Input.GetKeyUp(turnLeft)) {
			gameObject.BroadcastMessage("SetTurn", 0.0f);
		}
		if (Input.GetKeyUp(turnRight)) {
			gameObject.BroadcastMessage("SetTurn", 0.0f);
		}
	}
}




