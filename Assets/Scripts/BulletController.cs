using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public GameObject explosion;

	public float damage = 30.0f;
	public float radius = 20.0f;
	public float age = 15.0f;

	void Start () {
		rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
	}
	
	void Update () {
        age -= Time.deltaTime;

        if (age < 0) {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter(Collision other) {
    	// Find tanks and calculate damage based on radius and distance
		GameObject[] tanks = GameObject.FindGameObjectsWithTag("Tank");
		for (int i = 0; i < tanks.Length; i++) {
			DamageTank(tanks[i]);
		}
		
		// Make an explosion animation here and replace this dummy
		GameObject explosionInstance = (GameObject)Instantiate(explosion, transform.position, explosion.transform.rotation);
		Detonator det = explosionInstance.GetComponentInChildren<Detonator>();
		det.size = radius * 1.0f;
		GameObject.Destroy(gameObject);		
	}
    
    void DamageTank(GameObject tank) {
		float dist = Vector3.Distance(tank.transform.position, transform.position);
		if (dist < radius) {
			tank.GetComponent<HealthControl>().ApplyDamage((radius - dist) / radius * damage);
		}
    }
}
