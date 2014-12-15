using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthControl : MonoBehaviour {

	public GameObject damageTextPrefab;
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
		if (health > maxHealth) {
			health = maxHealth;
		}
		healthBarSlider.value -= damage / maxHealth;
			
		GameObject damageText = (GameObject)Instantiate(damageTextPrefab, transform.position, transform.rotation);
		damageText.GetComponent<DamageText>().SetText(Mathf.FloorToInt(-damage).ToString(), damage > 0 ? new Color(1, 0, 0) : new Color(0, 1, 0));
		damageText.transform.parent = transform;
		
		print ("Tank hit. Damage: " + damage + " Health:" + health);
		
		if (health < 0) {
			print ("Tank destroyed. Health:" + health);
			GameObject.Destroy(gameObject, 2.0f);
			Instantiate(deathExplosionPrefab, transform.position, transform.rotation);
		}
	}
	
}
