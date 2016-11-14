using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour {

    public GameObject laserDestroyPoint;
    public float speed;
    Rigidbody2D rigid;


    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        laserDestroyPoint = GameObject.Find("PlatformGenPoint");
    }
	
	// Update is called once per frame
	void Update () {
        rigid.velocity = new Vector2(speed, rigid.velocity.y);
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Asteroid")
        {
            (other.gameObject).SetActive(false);
            gameObject.SetActive(false);

        } 

    }

    void FixedUpdate()
    {
        if (transform.position.x > laserDestroyPoint.transform.position.x)
        {
            gameObject.SetActive(false);
        }
    }


}
