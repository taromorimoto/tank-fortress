using UnityEngine;
using System.Collections;

public class HealthControl : MonoBehaviour {

	public float health = 100.0f;

	void Start () {
	
	}
	
	void Update () {
	
	}
	
	public void ApplyDamage(float damage) {
		health -= damage;
		print ("Fortress hit. Damage: " + damage + " Health:" + health);
		if (health < 0) {
			// Make death animation here
			print ("Fortress destroyed. Health:" + health);
			GameObject.Destroy(gameObject);
		}
	}
	
}
