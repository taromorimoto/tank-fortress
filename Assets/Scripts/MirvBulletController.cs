using UnityEngine;
using System.Collections;

public class MirvBulletController : BulletController {

	public GameObject childMirvPrefab;
	public int mirvCount = 5;
	public bool canMirv = true;
	float spread = 0.5f;
	
	Vector3 prev = new Vector3();

	public void Update() {
		base.Update();

		if (canMirv) {
			if (prev.y > transform.position.y) {
				Vector3 dir = prev - transform.position;
				
				for (int i = 0; i < mirvCount; i++) {
					
					GameObject mirvInstance = (GameObject)Instantiate(childMirvPrefab, transform.position, transform.rotation);
					//mirvInstance.rigidbody.velocity = rigidbody.velocity;
					//mirvInstance.rigidbody.AddRelativeForce(rigidbody.velocity);
					//print (rigidbody.velocity);
					//print (transform.forward);
					//Vector3 s = new Vector3(transform.forward.x + Random.Range(-spread, spread), transform.forward.y, transform.forward.z + Random.Range(-spread, spread));
					Vector3 s = rigidbody.velocity;
					//Vector3 s = dir;
					Vector3 r = transform.right;
					//r = new Vector3(r.x * Random.Range(1.0f - spread, 1.0f + spread), 
					//                r.y * Random.Range(1.0f - spread, 1.0f + spread), 
					//                r.z * Random.Range(1.0f - spread, 1.0f + spread));
					
					r = new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), Random.Range(-spread, spread));
					s += r * 50.0f;
					print (s);
					mirvInstance.rigidbody.AddForce(s * charge * 50.0f);
				}
				//rigidbody.AddExplosionForce(1.0f, transform.position, 5.0f);
				canMirv = false;
			}
			prev = transform.position;
		}
	}
}
