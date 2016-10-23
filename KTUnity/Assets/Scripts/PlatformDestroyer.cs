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

		if (transform.position.x < platformDestroyPoint.transform.position.x) 
		{

			Destroy (gameObject);

		}
	
	}
}
