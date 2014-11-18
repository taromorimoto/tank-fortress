using UnityEngine;
using System.Collections;

public class CannonController : MonoBehaviour {

    public Transform launchPoint;
	public GameObject bullet;
    public float bulletVelocity = 1000;
    public float rateOfFire = 0.1f;

    float lastShot = 0;

	void Start () {
	
	}
	
	void Update () {
        lastShot += Time.deltaTime;

        bool fireKeyDown = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow);

        if (fireKeyDown) {
            if (lastShot > rateOfFire) {
                Fire();
                lastShot = 0;
            }
        }		
	
	}

    void Fire() {
        GameObject bulletInstance = (GameObject)Instantiate(bullet, launchPoint.position, launchPoint.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(launchPoint.forward * bulletVelocity);
    }


}
