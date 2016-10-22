using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 5f;
	public int jumpHeight;

	public Transform groundPoint;
	public float radius;
	public LayerMask groundMask;

	bool isGrounded;
    bool doubleJump = false;
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

        //Jumping + Doublejump
		isGrounded = Physics2D.OverlapCircle (groundPoint.position, radius, groundMask);

		if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) {

            //If player is pressing up and the cat is on the ground, then jump and reset double jump ability
			rb2D.AddForce (new Vector2 (0, jumpHeight));
            doubleJump = false;

		} else if (Input.GetKeyDown(KeyCode.UpArrow) && !isGrounded && !doubleJump)
        {
            //If pressing up, is not on ground, and doublejump has not been used, then if player presses up, the cat double jumps

            //cancelling out velocity from first jump to achieve a smoother second jump effect
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
            //double jump
            rb2D.AddForce(new Vector2(50, jumpHeight));
            //double jump set to true so player cannot infinitely jumping
            doubleJump = true;
        }
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere (groundPoint.position, radius);
	}

}
