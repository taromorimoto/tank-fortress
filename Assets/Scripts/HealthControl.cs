using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthControl : MonoBehaviour {

	public GameObject deathExplosionPrefab;
	public Slider healthBarSlider;
	public float health = 100.0f;

	float maxHealth;
	
	void Start () {
		maxHealth = health;
	}
	
	public void SetMaxHealth() {
		health = maxHealth;
		healthBarSlider.value = 1.0f;
	}
	
	void Update () {
	
	}
	
	public void ApplyDamage(float damage) {
		health -= damage;
		healthBarSlider.value -= damage / maxHealth;
		print ("Tank hit. Damage: " + damage + " Health:" + health);
		if (health < 0) {
			print ("Tank destroyed. Health:" + health);
			GameObject.Destroy(gameObject, 2.0f);
			GameObject bulletInstance = (GameObject)Instantiate(deathExplosionPrefab, transform.position, transform.rotation);
		}
	}
	
}
