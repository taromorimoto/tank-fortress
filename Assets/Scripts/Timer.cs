using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public float deactivateAfter;
	public float destroyAfter;
	
	float originalDeactivate = -1;
	
	void Start() {
		originalDeactivate = deactivateAfter;
	}
	
	void Update () {
		
		if (deactivateAfter > 0) {
			deactivateAfter -= Time.deltaTime;
			if (deactivateAfter <= 0) {
				deactivateAfter = originalDeactivate;
				gameObject.SetActive(false);
				print ("deactivate");
			}
		}
		
		if (destroyAfter > 0) {
			destroyAfter -= Time.deltaTime;
			if (destroyAfter <= 0) {
				Destroy(gameObject);
			}
		}
	}
	
	public void Reset() {
		if (originalDeactivate != -1) {
			deactivateAfter = originalDeactivate;
		}
	}
}
