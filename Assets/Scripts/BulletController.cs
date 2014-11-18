using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public float age = 1.0f;
    public float ageAfterHit = 0.1f;

	void Start () {
	
	}
	
	void Update () {
        age -= Time.deltaTime;

        if (age < 0) {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider other) {
        age = ageAfterHit;
        Light light = transform.FindChild("Point light").GetComponent<Light>();
        light.intensity *= 2;
    }
}
