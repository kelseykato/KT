using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {

	public GameObject pooledObject;

	public int pooledAmount;

	List<GameObject> pooledObjects;

	// Use this for initialization
	void Start () 
	{
	
		pooledObjects = new List<GameObject> ();

		for (int i = 0; i < pooledAmount; i++) 
		{
			GameObject obj = (GameObject)Instantiate (pooledObject);
			obj.SetActive (false);
			pooledObjects.Add (obj);
		}
	}

	// Gets pooled object in the list
	public GameObject GetPooledObject()
	{
		//Counts objects in pooledObjects list
		for (int i = 0; i < pooledObjects.Count; i++)
		{
			//if the object is not active in the scene, return object in the list
			if (!pooledObjects [i].activeInHierarchy)
			{
				return pooledObjects [i];
			}

		}
		GameObject obj = (GameObject) Instantiate (pooledObject);
		obj.SetActive (false);
		pooledObjects.Add (obj);
		return obj;

	}
}
