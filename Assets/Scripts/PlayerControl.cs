using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public GameObject terrain;
		
	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (terrain.collider.Raycast(ray, out hit, Mathf.Infinity)) {
				gameObject.BroadcastMessage("MoveTo", hit.point);
			}
		}
	}
}




