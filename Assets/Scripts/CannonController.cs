using UnityEngine;
using System.Collections;

public class CannonController : MonoBehaviour {

    public Transform launchPoint;
	public GameObject bullet;
    public float bulletVelocity = 1000;
	public float cooldownMax = 1.0f;
	public float baseCharge = 0.3f;
	
	bool charging = false;
	float charge = 0;
	bool fired = false;
	float cooldown = 1.0f;
	
	public void ChargeCannon() {
		print(gameObject.name + " charging");
		charging = true;
	}
	
	public void FireCannon() {
		print(gameObject.name + " fired");
		fired = true;
	}
	
	void Update () {
        cooldown += Time.deltaTime;
        if (cooldown > cooldownMax) {
			cooldown = cooldownMax;
        }
        
        if (charging) {
        	charge += Time.deltaTime;
        }

        if (fired) {
            //if (cooldown == cooldownMax) {
                Fire();
            //}
		}		
	}

    void Fire() {
        GameObject bulletInstance = (GameObject)Instantiate(bullet, launchPoint.position, launchPoint.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(launchPoint.forward * bulletVelocity * (charge + baseCharge));
		cooldown = 0;
		charge = 0;
		charging = false;
		fired = false;
	}

}
