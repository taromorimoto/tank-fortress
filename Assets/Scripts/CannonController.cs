using UnityEngine;
using System.Collections;

public class CannonController : MonoBehaviour {

    public Transform launchPoint;
	public GameObject bullet;
    public float bulletVelocity = 1000;
	public float cooldownMax = 1.0f;

	bool fired = false;
    float lastShot = 0;
	float cooldown = 1.0f;
	
	void Start () {
	
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

        if (fired) {
	        print ("muui!");
            if (cooldown == cooldownMax) {
                Fire();
                cooldown = 0;
            }
			fired = false;
		}		
	}

    void Fire() {
        GameObject bulletInstance = (GameObject)Instantiate(bullet, launchPoint.position, launchPoint.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(launchPoint.forward * bulletVelocity);
    }


}
