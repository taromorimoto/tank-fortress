﻿using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public GameObject explosion;

	public float damage = 30.0f;
	public float radius = 20.0f;
	public float age = 15.0f;
	public float bulletVelocity = 4000;
	public float energyUse = 0.2f;
	
	protected float charge;
	
	void Start () {
		rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
	}
	
	public void AddForce(Vector3 dir, float _charge) {
		charge = _charge;
		rigidbody.AddForce(dir * charge * bulletVelocity);
	}
	
    public void OnCollisionEnter(Collision other) {
		//print (other.gameObject.tag);
		if (other.gameObject.tag == "Projectile") {
    		return;
    	}

		// Find tanks and buldings. Calculate damage based on radius and distance.
		Collider[] _colliders = Physics.OverlapSphere(transform.position, radius);
		foreach (Collider hit in _colliders) {
			if (hit.gameObject.tag == "Building") {
				ApplyDamage(hit.gameObject.transform.parent.gameObject, hit.gameObject.renderer.bounds.center);
			} else if (hit.gameObject.tag == "Tank") {
				ApplyDamage(hit.gameObject, hit.gameObject.collider.bounds.center);
			}
		}
								
		// Make an explosion animation here and replace this dummy
		GameObject explosionInstance = (GameObject)Instantiate(explosion, transform.position, explosion.transform.rotation);
		Detonator det = explosionInstance.GetComponentInChildren<Detonator>();
		det.size = radius * 1.0f;
		GameObject.Destroy(gameObject);		
	}
    
	void ApplyDamage(GameObject target, Vector3 targetPos) {
		float dist = Vector3.Distance(targetPos, transform.position);
		float amount = (radius - dist) / radius * damage;
		if (amount > 0) {
			target.BroadcastMessage("ApplyDamage", amount);
		}
	}

}
