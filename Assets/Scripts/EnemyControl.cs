using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {

	GameObject player;

	float interval = 5.0f;
	float elapsed = 0;
	
	void Start () {
		player = GameObject.Find("PlayerTank");
	}
	
	void Update () {
		elapsed += Time.deltaTime;
		if (elapsed > interval) {
			gameObject.BroadcastMessage("MoveTo", player.transform.position);
			elapsed = 0;
		}
	}
}
