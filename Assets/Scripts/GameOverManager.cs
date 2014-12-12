using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {

	void FixedUpdate () {
		if (HasGameEnded()) {
			// Add here delay to load and show the winning player text etc! :)
			Application.LoadLevel("Battle");
		}
	}
	
	bool HasGameEnded() {
		GameObject[] tanks = GameObject.FindGameObjectsWithTag("Tank");
		if (tanks.Length == 1) {
			print("Winner: " + tanks[0].name);
			return true;
		} else if (tanks.Length == 0) {
			print("Both Players died!");
			return true;
		} else {
			return false;
		}
	}
}
