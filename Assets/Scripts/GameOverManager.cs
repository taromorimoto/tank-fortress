using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverManager : MonoBehaviour {

	public GameObject gameOverText;
	bool spacePressed = false;
	string text = "";
	
	void FixedUpdate () {
		if (HasGameEnded()) {
			gameOverText.GetComponent<Text>().text = text;
			gameOverText.SetActive(true);
			
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
			text = "THE WINNER IS " + tanks[0].name;
			audio.Stop();
			return true;
		} else if (tanks.Length == 0) {
			text = "BOTH PLAYERS DIE!";
			audio.Stop();
			return true;
		} else {
			return false;
		}
	}
}
