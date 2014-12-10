﻿using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

	public GameObject buildingMesh;
	public GameObject buildingCells;

	// Use this for initialization
	void Start () {
	
		buildingMesh.SetActive(true);
		buildingCells.SetActive(false);

	}

	public void Fracture() {

		Destroy(buildingMesh);
		buildingCells.SetActive(true);

	}

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Space)){
			Fracture();
		}
	
	}
}
