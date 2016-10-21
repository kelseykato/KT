using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public int speed;
	public int jumpHeight;

	Rigidbody2D rb2D;

	void Start () {

		rb2D = GetComponent<Rigidbody2D> ();

	}
	
	void Update () {

		Vector2 moveDirection = new Vector2 (Input.GetAxisRaw ("Horizontal") * speed, rb2D.velocity.y);
		rb2D.velocity = moveDirection;
	}
}
