using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageText : MonoBehaviour {
	
	void Start () {
		Destroy(gameObject, 2.0f);
	}
	
	void Update () {
		transform.position += new Vector3(0, 20.0f * Time.deltaTime, 0);
	}
	
	public void SetText(string text, Color color) {
		Text tc = GetComponent<Text>();
		tc.text = text;
		tc.color = color;
	}
}
