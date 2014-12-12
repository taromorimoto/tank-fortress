using UnityEngine;
using System.Collections;

public class HealthKit : MonoBehaviour {

	public float dist = 20.0f;

	void Start () {
		GameObject tank = GetLooserTank();
		if (tank != null) {
			Vector3 pos = tank.transform.position;
			transform.position = new Vector3(pos.x + Random.Range(-dist, dist), 100.0f, pos.z + Random.Range(-dist, dist));
		} else {
			Destroy(gameObject);
		}
	}
	
	GameObject GetLooserTank() {
		GameObject[] tanks = GameObject.FindGameObjectsWithTag("Tank");
		if (tanks.Length < 2) {
			return null;
		}
		
		if (tanks[0].GetComponent<HealthControl>().health > tanks[1].GetComponent<HealthControl>().health) {
			return tanks[1];
		} else if (tanks[0].GetComponent<HealthControl>().health < tanks[1].GetComponent<HealthControl>().health) {
			return tanks[0];
		} else {
			return null;
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
