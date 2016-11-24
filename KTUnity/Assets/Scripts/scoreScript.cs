using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scoreScript : MonoBehaviour {
    public Button backToMainButton;
    // Use this for initialization
    void Start () {
        backToMainButton = backToMainButton.GetComponent<Button>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void backToMain()
    {
        SceneManager.LoadScene("Menu");
    }
}
