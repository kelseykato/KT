using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public Transform platformGenerator;
	private Vector3 platformGenStartPoint;
    public float deathTimeDelay = 5.0f;
    public GUIText scoreText;
    public int score;
    public static string finalScore;


    private bool timeCounter;
    public GameObject player;
	private Vector3 playerStartPoint;
    PlayerMovement playerMovement;

    private PlatformDestroyer[] platformList;
    private float timeOfDeath;
	// Use this for initialization
	void Start () {

        DontDestroyOnLoad(gameObject);
	
		platformGenStartPoint = platformGenerator.position;
		playerStartPoint = player.transform.position;
        timeCounter = false;
        //function called for asteroids destroyed
        //UpdateScore();

    }

    // Update is called once per frame
    void Update () {

        if (player.activeSelf == true)
        {
            scoreText.text = "Score: " + System.Math.Ceiling((score * Time.time) / 10) * 10;
        } else {
            if (timeCounter == false)
            {
                timeOfDeath = Time.time;
                timeCounter = true;
                finalScore = (System.Math.Ceiling((score * Time.time) / 10) * 10).ToString();
               
            } else
            {
                if (Time.time - timeOfDeath > deathTimeDelay)
                {
                    SceneManager.LoadScene("Score");
                }
            }




        }

    }


}
