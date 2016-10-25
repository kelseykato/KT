using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Transform platformGenerator;
	private Vector3 platformGenStartPoint;

	public GameObject player;
	private Vector3 playerStartPoint;

	private PlatformDestroyer[] platformList;

	// Use this for initialization
	void Start () {
	
		platformGenStartPoint = platformGenerator.position;
		playerStartPoint = player.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//coroutine = method that runs independently of script
	public void RestartGame() 
	{
		StartCoroutine ("RestartGameCo");
	}

	//set player inactive when they fall off the screen
	//delay of 0.5s before game restarts 
	//after delay, set all existing platforms (except the initial two) to inactive 
	//so that they can be returned to object pool and so that we don't get multiple platforms
	//spawning on top of each other each time we restart
	//reset player's position and platformGen position to respective start points
	//once player and platforms are reset at start points, set player active again
	public IEnumerator RestartGameCo() 
	{
		player.SetActive (false);
		yield return new WaitForSeconds (0.5f);

		platformList = FindObjectsOfType<PlatformDestroyer> ();
		for (int i = 0; i < platformList.Length; i++) 
		{
			platformList [i].gameObject.SetActive (false);
		}
		player.transform.position = playerStartPoint;
		platformGenerator.position = platformGenStartPoint;
		player.SetActive (true);
	}

}
