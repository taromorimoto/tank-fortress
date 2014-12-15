using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

	public GameObject buildingMesh;
	public GameObject buildingCells;

	// Use this for initialization
	void Start () {
	
		buildingMesh.SetActive(true);
		buildingCells.SetActive(false);

	}

	public void ApplyDamage(float amount) {
		print ("Building is hit with damage: " + amount);

		Destroy(buildingMesh);
		buildingCells.SetActive(true);

	}
}
