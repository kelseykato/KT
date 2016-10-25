using UnityEngine;
using System.Collections;

public class PlatformDestroyer : MonoBehaviour {

	public GameObject platformDestroyPoint;

	// Use this for initialization
	void Start () {

		platformDestroyPoint = GameObject.Find ("PlatformDestroyPoint");
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//if the current position of the platform is less than the position of the destroyPoint
		//set the platform to inactive
		if (transform.position.x < platformDestroyPoint.transform.position.x) 
		{

			//Destroy (gameObject);
			gameObject.SetActive(false);

		}
	
	}
}
