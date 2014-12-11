using UnityEngine;
using System.Collections;

public class CollectableSpawner : MonoBehaviour {


	public GameObject spawnPrefab;
	public float spawnInterval = 15.0f;
	
	float timer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		
		if (timer > spawnInterval) {
			Instantiate(spawnPrefab);
			timer = 0;
		}
	}
}
