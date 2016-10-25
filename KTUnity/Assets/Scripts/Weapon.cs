using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public float fireRate = 0;
    public float Damage = 10;
    public LayerMask whatToHit;

    float timeToFire = 0;
    Transform firePoint;


	// Use this for initialization
	void Awake () {
        firePoint = transform.FindChild("FirePoint");

        if (firePoint == null)
        {
            Debug.LogError("No firePoint? WHAT?!");
        }

	}
	
	// Update is called once per frame
	void Update () {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                //if you press the fire button specified as "Fire1", it calls the shoot function defined below.
                Shoot();
            }
        } else {

            //if you hold down the fire button, it should keep shooting depending on the fire rate variable.

            if (Input.GetButton("Fire1") && Time.time > timeToFire) {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
	}

    void Shoot () {
        //Firing origin - eyes
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);

        //Firing endpoint = same y position as the origin but x value is far to the right so I added 100
        Vector2 firePointPositionEnd = new Vector2(firePoint.position.x + 100, firePoint.position.y);

        //Parameters for this is Origin, Direction (by subtracting the 2 variables above, you get direction), length, and what not to hit
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, firePointPositionEnd - firePointPosition, 100, whatToHit);
        Debug.DrawLine(firePointPosition, (firePointPositionEnd - firePointPosition) * 100, Color.cyan);
        if (hit.collider !=null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
        }
    }

}
