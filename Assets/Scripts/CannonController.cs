using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CannonController : MonoBehaviour {

	public Slider energySlider;
	public Transform launchPoint;
	public Transform mineLaunchPoint;
	public Text bulletText;
	public GameObject ammoSelectText;
	public string[] bulletNames;
	public GameObject[] bulletPrefabs;
	public GameObject aimPrefab;
	public AudioSource noEnergyAudio;
		
	public float cooldownMax = 1.0f;
	public float baseCharge = 0.3f;
	public float energyRegenerationSpeed = 0.03f;
	
	GameObject bulletPrefab;
	BulletController bulletComp;
	int bulletIndex = 0;
	GameObject aim;
	bool charging = false;
	float charge = 0;
	bool fired = false;
	float cooldown = 1.0f;
	
	void Start() {
		bulletPrefab = bulletPrefabs[bulletIndex];
		bulletComp = bulletPrefab.GetComponent<BulletController>();
	}

	void CreateAim() {
		aim = (GameObject)Instantiate(aimPrefab, GetAimPosition(), transform.parent.rotation);
	}

	Vector3 GetAimPosition() {
		return transform.parent.position + transform.parent.forward * (baseCharge + charge) * 70.0f;
	}
	
	public void UseNitro() {
		energySlider.value = 0;
	}
	
	public void ChangeAmmo() {
		bulletIndex++;
		if (bulletIndex >= bulletPrefabs.Length) {
			bulletIndex = 0;
		}
		bulletPrefab = bulletPrefabs[bulletIndex];
		bulletComp = bulletPrefab.GetComponent<BulletController>();
		
		energySlider.gameObject.GetComponentInChildren<EnergySlider>().threshold = bulletComp.energyUse;
		bulletText.text = bulletNames[bulletIndex];
		
		ammoSelectText.GetComponent<Text>().text = bulletNames[bulletIndex];
		ammoSelectText.GetComponent<Timer>().Reset();
		ammoSelectText.SetActive(true);
	}
	
	void DestroyAim() {
		GameObject.Destroy(aim);
	}
	
	public void ChargeCannon() {
		if (energySlider.value >= bulletComp.energyUse) {
			if (bulletIndex == 2) {
				print(gameObject.name + " dropped mine");
				fired = true;
			} else {
				print(gameObject.name + " charging");
				charging = true;
				CreateAim();
			}
		} else {
			noEnergyAudio.Play();
		}
	}
	
	public void FireCannon() {
		if (charging) {
			print(gameObject.name + " fired");
			fired = true;
			DestroyAim();
		}
	}
	
	public bool IsAiming() {
		return charging;
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
		float v = c * Mathf.Pow(0.785f, c + 0.5f);
		print (c + " -> " + v);
		return v;
	}

    void Fire() {
		if (energySlider.value > bulletComp.energyUse) {
			Transform launchPos = launchPoint;
			if (bulletIndex == 2) {
				launchPos = mineLaunchPoint;
			}
			
			GameObject bulletInstance = (GameObject)Instantiate(bulletPrefab, launchPos.position, launchPos.rotation);
			BulletController bullet = bulletInstance.GetComponent<BulletController>();
			bullet.AddForce(launchPos.forward, GetCharge());
			
			energySlider.value -= bullet.energyUse;
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
