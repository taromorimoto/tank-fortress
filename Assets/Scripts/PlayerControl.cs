using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public GameObject goTerrain;
	public float turnSpeed = 1.0f;
	public float driveSpeed = 1.0f;
	
	bool turning = false;
	bool driving = false;
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
			Vector3 forward = new Vector3(transform.forward.x, 0, transform.forward.z);
			Vector3 targetDir = target - transform.position;
			targetDir.y = 0;
			targetDir.Normalize();
			forward.Normalize();
			
			if (Vector3.Angle(targetDir, forward) > 5.0F) {
				Vector3 newDir = Vector3.RotateTowards(forward, targetDir, turnSpeed * Time.deltaTime, 0.0F);
				Debug.DrawRay(transform.position, newDir, Color.red);
				newDir.y = transform.forward.y;
				print (transform.rotation.eulerAngles.y + "   " + Vector3.Angle(targetDir, forward));
				newDir.Normalize();
				transform.rotation = Quaternion.LookRotation(newDir);
				//transform.LookAt(target);
				//transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
			} else {
				print("Target closer than 5 degrees, stopping turning.");
				turning = false;
				driving = true;
			}
		}
		
		if (driving) {
			float dist = Vector3.Distance(target, transform.position);
			if (dist > 1) {
				transform.position = Vector3.MoveTowards(transform.position, target, driveSpeed * Time.deltaTime);
				
			} else {
				print("Target closer than 1, stopping driving.");
				driving = false;
			}
		}
	}
}




