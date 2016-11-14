using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour
{

    public float speed;
    Rigidbody2D rigid;
    public int rotationSpeed = 10;


    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.AddTorque(rotationSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector2(speed, rigid.velocity.y);

    }
}
