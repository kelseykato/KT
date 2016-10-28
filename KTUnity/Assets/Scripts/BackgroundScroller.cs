using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

    public float scrollSpeed;
    public float tileSizeX;
    public float cameraPos;



    private Vector3 startPosition;

    // Use this for initialization
    void Start () {
        startPosition = transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        //float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeX) + Camera.main.transform.position.x;
        float newPosition = Time.time*scrollSpeed + Camera.main.transform.position.x;
        transform.position = startPosition + Vector3.right * newPosition;

        if (Camera.main.transform.position.x - transform.position.x > 150)
        {
            transform.position = Vector3.right * 1204;
        }

    }

}
