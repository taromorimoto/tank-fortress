using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float ratio = 1.0f;
	public float minDist = 200.0f;
	public GameObject brawlText;
	
	GameObject[] tanks;
	Vector3 target;
	float dist;
	float auxRatio = 1.0f;
	bool play = false;
	float driveInBeginPos = 1100.0f;
	float driveInBeginRot = 85.0f;
	float driveInEndRot;
	float driveInDuration = 4.0f;
	float driveInStartTime;
	
	void Start () {
		tanks = GameObject.FindGameObjectsWithTag("Tank");
		UpdateTarget();
		driveInStartTime = Time.time;
		driveInEndRot = transform.eulerAngles.x;
		tanks[0].GetComponent<PlayerControl>().enabled = false;
		tanks[1].GetComponent<PlayerControl>().enabled = false;
	}
	
	void UpdateTarget() {
		if (tanks[0] != null && tanks[1] != null) {
			target = Vector3.Lerp(tanks[0].transform.position, tanks[1].transform.position, 0.5f);
			dist = Vector3.Distance(tanks[0].transform.position, tanks[1].transform.position);
			
			Vector3 rel = tanks[0].transform.position - tanks[1].transform.position;
			float x = Mathf.Abs(rel.x);
			float z = Mathf.Abs(rel.z);
			
			auxRatio = (z - x) / z;
			if (auxRatio < 0) {
				auxRatio = 0;
			}
		}
	}
	
	void Update () {
		UpdateTarget();
		
		float calculatedDist = dist * (ratio + auxRatio);
		if (calculatedDist < minDist) {
			calculatedDist = minDist;
		}
		
		if (play) {
			Camera.main.transform.localPosition = new Vector3(0, 0, -calculatedDist);
		} else {
			float t = (Time.time - driveInStartTime) / driveInDuration;
			Camera.main.transform.localPosition = new Vector3(0, 0, -Mathf.SmoothStep(driveInBeginPos, calculatedDist, t));
			
			transform.eulerAngles = new Vector3(Mathf.SmoothStep(driveInBeginRot, driveInEndRot, t), 0, 0);
			
			if (t >= 1.0f) {
				play = true;
				print ("Camera drive in end.");
				brawlText.SetActive(true);
				tanks[0].GetComponent<PlayerControl>().enabled = true;
				tanks[1].GetComponent<PlayerControl>().enabled = true;
			}
		}
		
		transform.position = target;
	}
}
