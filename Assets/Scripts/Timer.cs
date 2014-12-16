using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public float deactivateAfter;
	public float destroyAfter;
	
	void Update () {
		
		if (deactivateAfter > 0) {
			deactivateAfter -= Time.deltaTime;
			if (deactivateAfter <= 0) {
				gameObject.SetActive(false);
			}
		}
		
		if (destroyAfter > 0) {
			destroyAfter -= Time.deltaTime;
			if (destroyAfter <= 0) {
				Destroy(gameObject);
			}
		}
	}
}
