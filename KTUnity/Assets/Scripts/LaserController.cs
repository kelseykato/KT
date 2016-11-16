using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour {

    public GameObject laserDestroyPoint;
    public float speed;
    Rigidbody2D rigid;

    private float positionA;
    private float positionB;
    private bool positionState;
    public float positionCheckDelay;
    private float startTime;


    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        laserDestroyPoint = GameObject.Find("PlatformGenPoint");
        positionState = false;
        positionA = transform.position.x;
        startTime = Time.time;

    }
	
	// Update is called once per frame
	void Update () {
        rigid.velocity = new Vector2(speed, rigid.velocity.y);

        if (Time.time - startTime > positionCheckDelay)
        {
            positionB = transform.position.x;
            if (positionB == positionA)
            {
                gameObject.SetActive(false);
            } else
            {
                startTime = Time.time;
                positionA = transform.position.x;
            }
        }



	
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
