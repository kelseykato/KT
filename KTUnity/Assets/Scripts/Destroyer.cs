using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

    void onTrggerEnter2d(Collider2D other)
    {
        //
        if(other.tag == "Player")
        {
            Debug.Break();
            return;
        }

        if (other.gameObject.transform.parent)
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }


}
