using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public float damage = 30.0f;
	public float age = 1.0f;

	void Start () {
		rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
	}
	
	void Update () {
        age -= Time.deltaTime;

        if (age < 0) {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider other) {
    	// Make an explosion animation here
    	GameObject.Destroy(gameObject);
    }
}
