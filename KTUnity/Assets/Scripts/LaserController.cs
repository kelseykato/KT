using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour {

    public float speed;
    Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        rigid.velocity = new Vector2(speed, rigid.velocity.y);
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Asteroid")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

}
