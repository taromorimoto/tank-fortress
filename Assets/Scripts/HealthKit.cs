using UnityEngine;
using System.Collections;

public class HealthKit : MonoBehaviour {

	public float dist = 20.0f;

	void Start () {
		Vector3 pos = GetLooserTankPosition();
		transform.position = new Vector3(pos.x + Random.Range(-dist, dist), 100.0f, pos.z + Random.Range(-dist, dist));
	}
	
	Vector3 GetLooserTankPosition() {
		GameObject[] tanks = GameObject.FindGameObjectsWithTag("Tank");
		if (tanks.Length < 2)
			Destroy(gameObject);
		
		if (tanks[0].GetComponent<HealthControl>().health > tanks[1].GetComponent<HealthControl>().health) {
			return tanks[1].transform.position;
		} else {
			return tanks[0].transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Tank") {
			HealthControl health = other.gameObject.GetComponent<HealthControl>();
			health.SetMaxHealth();
			Destroy(gameObject);
		}
		
	}
}
