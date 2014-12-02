using UnityEngine;
using System.Collections;

public class MoveTracks : MonoBehaviour {

	public float scrollSpeed = 0.1f;

	float offset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		offset += Time.deltaTime * -scrollSpeed;

		if (offset < -1.0f)
			offset = 0.0f;

		renderer.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
		renderer.material.SetTextureOffset("_BumpMap", new Vector2(0, offset));

	}
}
