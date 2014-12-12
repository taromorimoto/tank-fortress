﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float ratio = 1.0f;
	public float minDist = 200.0f;
	
	GameObject[] tanks;
	Vector3 target;
	float dist;
	
	void Start () {
		tanks = GameObject.FindGameObjectsWithTag("Tank");
		UpdateTarget();
	}
	
	void UpdateTarget() {
		if (tanks[0] != null && tanks[1] != null) {
			target = Vector3.Lerp(tanks[0].transform.position, tanks[1].transform.position, 0.5f);
			dist = Vector3.Distance(tanks[0].transform.position, tanks[1].transform.position);
		}
	}
	
	void Update () {
		UpdateTarget();
		
		float calculatedDist = dist * ratio;
		if (calculatedDist < minDist) {
			calculatedDist = minDist;
		}
		
		Camera.main.transform.localPosition = new Vector3(0, 0, -calculatedDist);
		
		transform.position = target;
	}

}
