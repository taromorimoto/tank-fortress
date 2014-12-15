using UnityEngine;
using System.Collections;

public class MineController : BulletController {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	public void OnCollisionEnter(Collision other) {
		//print (other.gameObject.tag);
		if (other.gameObject.tag == "Tank") {
			base.OnCollisionEnter(other);
		}
		
	}
}
