using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class EnergySlider : MonoBehaviour {


	Image img;
	Slider slider;
	Color original;
	public float threshold = 0.3f;
	public Color color = new Color(1.0f, 0, 0, 1.0f);
	
	// Use this for initialization
	void Start () {
		slider = GetComponentInParent<Slider>();
		img = GetComponentInChildren<Image>();
		original = img.color;
		print (original);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (slider.value < threshold) {
			img.color = color;
		} else {
			img.color = original;
		}
		
	}
}
