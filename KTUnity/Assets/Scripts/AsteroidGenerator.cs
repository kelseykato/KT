using UnityEngine;
using System.Collections;

public class AsteroidGenerator : MonoBehaviour
{

    public GameObject platform;
    public Transform genPoint;
    public float distBetween;

    private float platformWidth;

    public float distBetweenMin;
    public float distBetweenMax;

    //public GameObject[] platforms;
    private int asteroidPicker;
    private float asteroidWidth;


    public ObjectPooler[] objectPools;
    public GameObject mainCharacter;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    // Use this for initialization
    void Start()
    {
        asteroidWidth = objectPools[0].pooledObject.GetComponent<CircleCollider2D>().radius;
        mainCharacter = GameObject.Find("Main Character");

        minHeight = -20;
        maxHeight = 20;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (transform.position.x < genPoint.position.x)
        {

            distBetween = Random.Range(distBetweenMin, distBetweenMax);

            //picks a platform from either RBRoad, medium ground, or small ground to spawn
            asteroidPicker = Random.Range(0, objectPools.Length);

            heightChange = mainCharacter.transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            //so that we don't keep generating platforms in an upward direction like a staircase
            //also so we don't keep generating platforms in a downward direction
            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            transform.position = new Vector3(transform.position.x + (asteroidWidth / 2) + distBetween, heightChange, transform.position.z);


            //Instantiate (/* platform */platforms[platformPicker], transform.position, transform.rotation);
            //new platform = free object in the list
            //gets a platform from the objectPools array at the index corresponding
            //to the random value chosen by platformPicker
            GameObject newAsteroid = objectPools[asteroidPicker].GetPooledObject();

            newAsteroid.transform.position = transform.position;
            newAsteroid.transform.rotation = transform.rotation;
            newAsteroid.SetActive(true);


        }
    }
}
