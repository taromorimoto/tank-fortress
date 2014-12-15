using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverManager : MonoBehaviour {

	public AudioSource player1;
	public AudioSource player2;
	public GameObject gameOverText;
	bool spacePressed = false;
	string winnerName = "";
	string text = "";
	bool win = false;
	
	void FixedUpdate () {
		if (HasGameEnded()) {
			if (!win) {
				gameOverText.GetComponent<Text>().text = text;
				gameOverText.SetActive(true);
				
				if (winnerName == "PLAYER 1") {
					player1.Play();
				} else if (winnerName == "PLAYER 2") {
					player2.Play();
				}
			}
			win = true;
			
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
			text = "THE WINNER IS " + tanks[0].name + "!";
			winnerName = tanks[0].name;
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
