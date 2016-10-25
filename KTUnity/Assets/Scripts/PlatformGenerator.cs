using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

	public GameObject platform;
	public Transform genPoint;
	public float distBetween;

	private float platformWidth;

	public float distBetweenMin;
	public float distBetweenMax;

	//public GameObject[] platforms;
	private int platformPicker;
	private float[] platformWidths;


	public ObjectPooler[] objectPools;

	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;

	// Use this for initialization
	void Start () 
	{

		//platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
		//gets the length of the given platform and adds it to the objectPools array
		platformWidths = new float[objectPools.Length];

		for (int i = 0; i < objectPools.Length; i++) 
		{
			//gets the width of the given platform in the objectPools list
			//assigns width to value at index i in platformWidths array
			platformWidths[i] = objectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
		}

		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;


	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{

		if (transform.position.x < genPoint.position.x) 
		{

			distBetween = Random.Range (distBetweenMin, distBetweenMax);

			//picks a platform from either RBRoad, medium ground, or small ground to spawn
			platformPicker = Random.Range (0, objectPools.Length);

			heightChange = transform.position.y + Random.Range (maxHeightChange, -maxHeightChange);

			//so that we don't keep generating platforms in an upward direction like a staircase
			//also so we don't keep generating platforms in a downward direction
			if (heightChange > maxHeight) {
				heightChange = maxHeight;
			} else if (heightChange < minHeight) {
				heightChange = minHeight;
			}

			transform.position = new Vector3 (transform.position.x + (platformWidths[platformPicker] / 2) + distBetween, heightChange, transform.position.z);
		

			//Instantiate (/* platform */platforms[platformPicker], transform.position, transform.rotation);
			//new platform = free object in the list
			//gets a platform from the objectPools array at the index corresponding
			//to the random value chosen by platformPicker
			GameObject newPlatform = objectPools[platformPicker].GetPooledObject();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);


		}
	}
}
	 