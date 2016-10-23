﻿using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

    void onTriggerEnter2D(Collider2D other)
    {

        //can't figure out why this isn't working yet
        if(other.tag == "Player")
        {
            //If cat falls off, then game ends.  Edit this to End Game Screen
            Debug.Break();
            return;
        }

        if (other.gameObject.transform.parent)
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
        else
        {
            //Destroy(other.gameObject);
			gameObject.SetActive(false);
        }
    }


}
