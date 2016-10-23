using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

	public GameObject platform;
	public Transform genPoint;
	public float distBetween;

	private float platformWidth;

	public float distBetweenMin;
	public float distBewteenMax;

	public ObjectPooler objectPool;

	// Use this for initialization
	void Start () 
	{
	
		platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{

		if (transform.position.x < genPoint.position.x) 
		{

			distBetween = Random.Range (distBetweenMin, distBewteenMax);

			transform.position = new Vector3 (transform.position.x + (platformWidth /2) + distBetween, transform.position.y, transform.position.z);

			//Instantiate (platform, transform.position, transform.rotation);
			//new platform = free object in the list
			GameObject newPlatform = objectPool.GetPooledObject();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);
		}
	}
}
	 