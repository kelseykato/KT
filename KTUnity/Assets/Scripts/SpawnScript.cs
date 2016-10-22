using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

    //a collection of objects to spawn(Array)
    public GameObject[] obj;

    //variables to define how fast things spawn. In this case, randomly spawn between 1 and 2 seconds.
    public float spawnMin = 1f;
    public float spawnMax = 2f;
	// Use this for initialization
	void Start () {
        Spawn();
	}

	void Spawn () {

        //create random object in the obj array.  Spawns at Transform.position and Quaternion makes it so it does not rotate.
        Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);

        //After a random period of time between spawnMin and spawnMax, the function calls on itself and spawns additional things in the array obj
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));
	
	}
}
