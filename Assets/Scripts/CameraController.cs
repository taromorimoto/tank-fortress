using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float ratio = 1.0f;
	public float minDist = 200.0f;
	
	GameObject[] tanks;
	Vector3 target;
	float dist;
	float auxRatio = 1.0f;
	
	void Start () {
		tanks = GameObject.FindGameObjectsWithTag("Tank");
		UpdateTarget();
	}
	
	void UpdateTarget() {
		if (tanks[0] != null && tanks[1] != null) {
			target = Vector3.Lerp(tanks[0].transform.position, tanks[1].transform.position, 0.5f);
			dist = Vector3.Distance(tanks[0].transform.position, tanks[1].transform.position);
			
			Vector3 rel = tanks[0].transform.position - tanks[1].transform.position;
			float x = Mathf.Abs(rel.x);
			float z = Mathf.Abs(rel.z);
			
			auxRatio = (z - x) / z;
			if (auxRatio < 0)
				auxRatio = 0;
			/*			
			if (x > z) {
				auxRatio = (x - z) / x;	
			}
			if (z > x) {
				auxRatio = (z - x) / z;	
			}
			if (z == x) {
				auxRatio = 0;	
			}
			*/
			//print (rel.x + " / " + rel.z);
		}
	}
	
	void Update () {
		UpdateTarget();
		
		float calculatedDist = dist * (ratio + auxRatio);
		if (calculatedDist < minDist) {
			calculatedDist = minDist;
		}
		
		Camera.main.transform.localPosition = new Vector3(0, 0, -calculatedDist);
		
		transform.position = target;
	}

}
