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
    public int finalScore;

    public GameObject player;
	private Vector3 playerStartPoint;

	private PlatformDestroyer[] platformList;
    public float timeOfDeath;
	// Use this for initialization
	void Start () {
	
		platformGenStartPoint = platformGenerator.position;
		playerStartPoint = player.transform.position;
        GameObject mainCharacter = GameObject.Find("Main Character");
        PlayerMovement playerMovement = mainCharacter.GetComponent<PlayerMovement>();
        timeOfDeath = playerMovement.timeOfDeath;
        //function called for asteroids destroyed
        //UpdateScore();
    }

    // Update is called once per frame
    void Update () {

            scoreText.text = "Score: " + System.Math.Ceiling((score * Time.time) / 10) * 10;

        if (Time.time - timeOfDeath > deathTimeDelay )
        {
            SceneManager.LoadScene("Menu");
        }

    }


}
