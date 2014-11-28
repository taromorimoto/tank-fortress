using UnityEngine;
using System.Collections;

public class HealthControl : MonoBehaviour {

	public float health = 100.0f;

	void Start () {
	
	}
	
	void Update () {
	
	}
	
	
	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Projectile") {
			BulletController bullet = col.gameObject.GetComponent<BulletController>();
			health -= bullet.damage;
			print ("Fortress hit. Health:" + health);
			if (health < 0) {
				// Make death animation here
				print ("Fortress destroyed. Health:" + health);
				GameObject.Destroy(gameObject);
			}
		}
	}
	
}
