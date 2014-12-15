using UnityEngine;
using System.Collections;

public class HealthKit : MonoBehaviour {

	public float dist = 20.0f;
	GameObject[] tanks;
	
	void Start () {
		tanks = GameObject.FindGameObjectsWithTag("Tank");
		if (tanks.Length < 2) {
			Destroy(gameObject);
			return;
		}
		
		float positionRatio = GetPositionRatio();
		
		if (Mathf.Abs(positionRatio) < 0.95f) {
			Vector3 target = Vector3.Lerp(tanks[0].transform.position, tanks[1].transform.position, 0.5f * positionRatio);
			transform.position = new Vector3(target.x + Random.Range(-dist, dist), 100.0f, target.z + Random.Range(-dist, dist));
		} else {
			Destroy(gameObject);
		}
	}
	
	float GetPositionRatio() {
		return tanks[0].GetComponent<HealthControl>().health / tanks[1].GetComponent<HealthControl>().health;
	}
	
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Tank") {
			HealthControl health = other.gameObject.GetComponent<HealthControl>();
			health.SetMaxHealth();
			Destroy(gameObject);
		}
		
	}
}
