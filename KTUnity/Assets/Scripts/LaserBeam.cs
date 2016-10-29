using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public float fireRate = 0;
    public float Damage = 10;
    public LayerMask whatToHit;
    private LineRenderer lineRenderer;


    float timeToFire = 0;
    Transform firePoint;


	// Use this for initialization
	void Awake () {
        firePoint = transform.FindChild("FirePoint");
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.useWorldSpace = true;

        if (firePoint == null)
        {
            Debug.LogError("No firePoint? WHAT?!");
        }

	}
	
	// Update is called once per frame
	void Update () {
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        Vector2 firePointPositionEnd = new Vector2(firePoint.position.x + 100, firePoint.position.y);

        lineRenderer.SetPosition(0, firePointPosition);
        lineRenderer.SetPosition(1, firePointPositionEnd);

        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Jump"))
            {
                //if you press the fire button specified as "Fire1", it calls the shoot function defined below.
                lineRenderer.enabled = true;
                //Parameters for this is Origin, Direction (by subtracting the 2 variables above, you get direction), length, and what not to hit
                RaycastHit2D hit = Physics2D.Raycast(firePointPosition, firePointPositionEnd - firePointPosition, 100, whatToHit);
                Debug.DrawLine(firePointPosition, (firePointPositionEnd - firePointPosition) * 100, Color.cyan);



                if (hit.collider != null)
                {
                    Debug.DrawLine(firePointPosition, hit.point, Color.red);
                }
            } else if (Input.GetButtonUp("Jump"))
            {
                lineRenderer.enabled = false;
            }
        } else {

            //if you hold down the fire button, it should keep shooting depending on the fire rate variable.

            if (Input.GetButton("Jump") && Time.time > timeToFire) {
                timeToFire = Time.time + 1 / fireRate;
                //Parameters for this is Origin, Direction (by subtracting the 2 variables above, you get direction), length, and what not to hit
                RaycastHit2D hit = Physics2D.Raycast(firePointPosition, firePointPositionEnd - firePointPosition, 100, whatToHit);
                Debug.DrawLine(firePointPosition, (firePointPositionEnd - firePointPosition) * 100, Color.cyan);



                if (hit.collider != null)
                {
                    Debug.DrawLine(firePointPosition, hit.point, Color.red);
                }
            }
        }
	}


}
