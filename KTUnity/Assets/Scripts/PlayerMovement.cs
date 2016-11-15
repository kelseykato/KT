using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	public float speed = 5f;
	//stores initial speed so that each time game resets, speed resets
	private float speedStore;
	public int jumpHeight;
    public float timeOfDeath;

	public float speedMultiplier;
	//set distance that indicates when player will speed up in game
	public float speedIncreaseMilestone; 
	//stores initial speed increase value so that each time game restarts, increase counter is reset
	private float speedIncreaseMilestoneStore;
	private float speedMilestoneCount;
	//stores initial milestone so that each time game restarts, milestone Counter is reset
	private float speedMilestoneCountStore;

	public Transform groundPoint;
	public float radius;
	public LayerMask groundMask;

	bool isGrounded;
    bool doubleJump = false;
	Rigidbody2D rb2D;

	public GameManager theGameManager;
    public Transform FirePoint;
    public GameObject laser;
    public ObjectPooler[] objectPools;
    private int laserPicker;

    void Start () 
	{

		rb2D = GetComponent<Rigidbody2D> ();

		//so that speed doesn't automatically increase at the start of the game
		speedMilestoneCount = speedIncreaseMilestone;

		//inital speed and speedMilestoneCount values for each time game restarts
		speedStore = speed;
		speedMilestoneCountStore = speedMilestoneCount;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;

	}
	
	void Update () 
	{

		//if current position is past the current milestone count, increase count
		//by constant speedIncreaseMilestone value
		//new constant = old constant + current milestoneCount
		//this ensures that the longer the game goes on, the intervals at which
		//player increases speed get bigger (the player will have to go longer distances
		//before the speed increases again
		//new speed = old speed times constant speed multiplier
		if (transform.position.x > speedMilestoneCount) 
		{

			speedMilestoneCount += speedIncreaseMilestone;

			speedIncreaseMilestone = speedIncreaseMilestone + speedMilestoneCount;

			speed = speed * speedMultiplier;

		}
        //Movement Speed - default speed is defined above as a float in speed.  If no keys are pressed, default speed is defined as 5.
        //If right is pressed speed is 5 + 2 and if left is pressed it's 5 - 2

        if (Input.GetAxis("Horizontal") == 0)
        {
            rb2D.velocity = new Vector2(speed, rb2D.velocity.y);

        } else if (Input.GetAxis("Horizontal") == 1)
        {
            rb2D.velocity = new Vector2(speed + 2, rb2D.velocity.y);
        } else if (Input.GetAxis("Horizontal") == -1)
        {
            rb2D.velocity = new Vector2(speed - 2, rb2D.velocity.y);
        }

        //Jumping + Doublejump
		isGrounded = Physics2D.OverlapCircle (groundPoint.position, radius, groundMask);

		if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) 
		{

            //If player is pressing up and the cat is on the ground, then jump and reset double jump ability
			rb2D.AddForce (new Vector2 (0, jumpHeight));
            doubleJump = false;

		} else if (Input.GetKeyDown(KeyCode.UpArrow) && !isGrounded && !doubleJump)
        {
            //If pressing up, is not on ground, and doublejump has not been used, then if player presses up, the cat double jumps

            //cancelling out velocity from first jump to achieve a smoother second jump effect
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
            //double jump
            rb2D.AddForce(new Vector2(0, jumpHeight));
            //double jump set to true so player cannot infinitely jumping
            doubleJump = true;
        }


        if (Input.GetButtonDown("Jump"))
        {
            laserPicker = Random.Range(0, objectPools.Length);
            GameObject newLaser = objectPools[laserPicker].GetPooledObject();

            newLaser.transform.position = FirePoint.position;
            newLaser.transform.rotation = FirePoint.rotation;
            newLaser.SetActive(true);
        }

        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("Menu");
        }

	}

	//upon collision, what is the other object we (player) are colliding with
	//each time game restarts, resets speed, speedIncreaseMilestone and speedMilestoneCount values


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Asteroid" || other.tag == "killbox")
        {
            timeOfDeath = Time.time;
            (other.gameObject).SetActive(false);
            gameObject.SetActive(false);


        }
    }





    void OnDrawGizmos() 
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere (groundPoint.position, radius);
	}

}
