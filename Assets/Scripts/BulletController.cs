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
		// Find buildings and based on radius and distance facture them
		Collider[] _colliders = Physics.OverlapSphere(transform.position, radius);
		foreach (Collider hit in _colliders) {
			if (hit.gameObject.tag == "Building") {
				FractureBuilding(hit.gameObject);
			} else if (hit.gameObject.tag == "Tank") {
				DamageTank(hit.gameObject);
			}
		}
								
		// Make an explosion animation here and replace this dummy
		GameObject explosionInstance = (GameObject)Instantiate(explosion, transform.position, explosion.transform.rotation);
		Detonator det = explosionInstance.GetComponentInChildren<Detonator>();
		det.size = radius * 1.0f;
		GameObject.Destroy(gameObject);		
	}
    
	void DamageTank(GameObject tank) {
		float dist = Vector3.Distance(tank.transform.position, transform.position);
		float amount = (radius - dist) / radius * damage;
		if (amount > 0) {
			tank.GetComponent<HealthControl>().ApplyDamage(amount);
		}
	}
	
	void FractureBuilding(GameObject building) {
		building.transform.parent.gameObject.GetComponent<Building>().Fracture();
	}
}
