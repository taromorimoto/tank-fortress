using UnityEngine;
using System.Collections;

public class CannonController : MonoBehaviour {

    public Transform launchPoint;
	public GameObject bullet;
    public float bulletVelocity = 1000;
	public float cooldownMax = 1.0f;
	
    float lastShot = 0;
	float cooldown = 1.0f;
	
	void Start () {
	
	}
	
	void Update () {
        cooldown += Time.deltaTime;
        if (cooldown > cooldownMax) {
			cooldown = cooldownMax;
        }

        bool fireKeyDown = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow);

        if (fireKeyDown) {
            if (cooldown == cooldownMax) {
                Fire();
                cooldown = 0;
            }
        }		
	
	}

    void Fire() {
        GameObject bulletInstance = (GameObject)Instantiate(bullet, launchPoint.position, launchPoint.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(launchPoint.forward * bulletVelocity);
    }


}
