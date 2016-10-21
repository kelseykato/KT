using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public Transform target; //what the camera is following
	public float smoothing; //dampening effect

	Vector3 offset; //difference between character and camera

	float lowestY; //lowest point that camera can go

	void Start () {
	
		offset = transform.position - target.position; //maintain diff. in offset

		lowestY = transform.position.y; //y-coord of initial position of camera
	}
	
	void FixedUpdate () {

		Vector3 targetCamPosition = target.position + offset; //where the camera wants to be located

		transform.position = Vector3.Lerp (transform.position, targetCamPosition, smoothing * Time.deltaTime);

		if (transform.position.y < lowestY) {
			transform.position = new Vector3 (transform.position.x, lowestY, transform.position.z);
	
		}
	}
}
