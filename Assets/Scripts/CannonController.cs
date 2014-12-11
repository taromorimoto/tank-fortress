using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CannonController : MonoBehaviour {

	public Slider energySlider;
    public Transform launchPoint;
	public GameObject bullet;
	public GameObject aimPrefab;
		
	public float bulletVelocity = 1000;
	public float cooldownMax = 1.0f;
	public float baseCharge = 0.3f;
	public float energyUsePerShot = 0.1f;
	public float energyRegenerationSpeed = 0.03f;
	public float aimTweak = 60.0f;
	
	GameObject aim;
	bool charging = false;
	float charge = 0;
	bool fired = false;
	float cooldown = 1.0f;

	void CreateAim() {
		aim = (GameObject)Instantiate(aimPrefab, GetAimPosition(), transform.parent.rotation);
	}

	Vector3 GetAimPosition() {
		float c = (baseCharge + charge);
		float v = c * Mathf.Pow(0.95f, 0.5f) * aimTweak;
		return transform.parent.position + transform.parent.forward * v;
	}
	
	public void UseNitro() {
		energySlider.value = 0;
	}
	
	void DestroyAim() {
		GameObject.Destroy(aim);
	}
	
	public void ChargeCannon() {
		print(gameObject.name + " charging");
		charging = true;
		CreateAim();
	}
	
	public void FireCannon() {
		print(gameObject.name + " fired");
		fired = true;
		DestroyAim();
	}
	
	void Update () {
        cooldown += Time.deltaTime;
		energySlider.value += energyRegenerationSpeed * Time.deltaTime;
		if (energySlider.value > 1.0f) {
			energySlider.value = 1.0f;
		}
		
		if (cooldown > cooldownMax) {
			cooldown = cooldownMax;
        }
        
        if (charging) {
        	charge += Time.deltaTime;
        	if (aim != null) {
				aim.transform.position = GetAimPosition();
        	}
		}

        if (fired) {
            //if (cooldown == cooldownMax) {
                Fire();
            //}
		}		
	}
	
	float GetCharge() {
		float c = charge + baseCharge;
		float v = c * Mathf.Pow(0.85f, c + 0.5f);
		print (c + " -> " + v);
		return v;
	}

    void Fire() {
		if (energySlider.value > energyUsePerShot) {
			GameObject bulletInstance = (GameObject)Instantiate(bullet, launchPoint.position, launchPoint.rotation);
			bulletInstance.GetComponent<Rigidbody>().AddForce(launchPoint.forward * bulletVelocity * GetCharge());
			energySlider.value -= energyUsePerShot;
			if (energySlider.value < 0) {
				energySlider.value = 0;
			}
		}
		cooldown = 0;
		charge = 0;
		charging = false;
		fired = false;
	}

}
