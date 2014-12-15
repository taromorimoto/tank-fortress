using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {

	bool spacePressed = false;
	
	void FixedUpdate () {
		if (HasGameEnded()) {
			// Add here delay to load and show the winning player text etc! :)
			
			if (spacePressed) {
				Application.LoadLevel("Intro");
			}
		}
	}
	
	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			spacePressed = true;
		}
	}
	
	bool HasGameEnded() {
		GameObject[] tanks = GameObject.FindGameObjectsWithTag("Tank");
		if (tanks.Length == 1) {
			print("Winner: " + tanks[0].name);
			audio.Stop();
			return true;
		} else if (tanks.Length == 0) {
			print("Both Players died!");
			audio.Stop();
			return true;
		} else {
			return false;
		}
	}
}
