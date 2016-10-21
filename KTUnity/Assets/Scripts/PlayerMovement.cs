using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public int speed;
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

		Vector2 moveDirection = new Vector2 (Input.GetAxisRaw ("Horizontal") * speed, rb2D.velocity.y);
		rb2D.velocity = moveDirection;

		isGrounded = Physics2D.OverlapCircle (groundPoint.position, radius, groundMask);


		if (Input.GetAxisRaw ("Horizontal") == 1) {
			transform.localScale = new Vector3 (1, 1, 1);
		}

		if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) {
			rb2D.AddForce (new Vector2 (0, jumpHeight));
		}
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere (groundPoint.position, radius);
	}

}
