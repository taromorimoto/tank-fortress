using UnityEngine;
using System.Collections;

public class MirvBulletController : BulletController {

	public GameObject childMirvPrefab;
	public int mirvCount = 5;
	public bool canMirv = true;
	float spread = 0.5f;
	
	Vector3 prev = new Vector3();

	void Update() {

		if (canMirv) {
			if (prev.y > transform.position.y) {
				for (int i = 0; i < mirvCount; i++) {
					GameObject mirvInstance = (GameObject)Instantiate(childMirvPrefab, transform.position, transform.rotation);
					Vector3 r = new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), Random.Range(-spread, spread));
					Vector3 s = rigidbody.velocity;
					s += r * 50.0f;
					mirvInstance.rigidbody.AddForce(s * charge * 50.0f);
				}
				canMirv = false;
			}
			prev = transform.position;
		}
	}
}
