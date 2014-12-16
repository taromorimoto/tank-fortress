using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour {

	public float reloadDelay = 0.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKey){
			Application.LoadLevel (1);
		}

		reloadDelay += Time.deltaTime;
		if (reloadDelay > 60 * 5) {
			Application.LoadLevel(0);
		}
	}
}
