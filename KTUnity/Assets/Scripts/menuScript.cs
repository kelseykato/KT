using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

    public Button playButton;
    public Button exitButton;

	// Use this for initialization
	void Start () {
        playButton = playButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartLevel()
    {
        SceneManager.LoadScene("First");
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
