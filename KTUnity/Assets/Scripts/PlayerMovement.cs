using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 5f;
	public int jumpHeight;

	public Transform groundPoint;
	public float radius;
	public LayerMask groundMask;

	bool isGrounded;
	Rigidbody2D rb2D;

	void Start () {

		rb2D = GetComponent<Rigidbody2D> ();

	}
	
	void Update () {
        //Movement Speed - default speed is defined above as a float in speed.  If no keys are pressed, default speed is defined as 5.
        //If right is pressed speed is 5 + 2 and if left is pressed it's 5 - 2

        if (Input.GetAxis("Horizontal") == 0)
        {
            rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
        } else if (Input.GetAxis("Horizontal") == 1)
        {
            rb2D.velocity = new Vector2(speed + 2, rb2D.velocity.y);
        } else if (Input.GetAxis("Horizontal") == -1)
        {
            rb2D.velocity = new Vector2(speed - 2, rb2D.velocity.y);
        }

        //Jumping
		isGrounded = Physics2D.OverlapCircle (groundPoint.position, radius, groundMask);

		if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) {
			rb2D.AddForce (new Vector2 (0, jumpHeight));
		}
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere (groundPoint.position, radius);
	}

}
