using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public GameObject goTerrain;
	public float turnSpeed = 1.0f;

	bool turning = false;
	Vector3 target;
	
	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (goTerrain.collider.Raycast(ray, out hit, Mathf.Infinity)) {
				target = hit.point;
				turning = true;
			}
		}
		
		if (turning) {
			Vector3 targetDir = target - transform.position;
			float step = turnSpeed * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
			Debug.DrawRay(transform.position, newDir, Color.red);
			transform.rotation = Quaternion.LookRotation(newDir);
		}
	}
}