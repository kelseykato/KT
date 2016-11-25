using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreNumberScript : MonoBehaviour {

    public GameObject GameManagerRef;
    Text score;
	// Use this for initialization
	void Start () {
        GameManagerRef = GameObject.Find("GameManager");
        score = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
        score.text = GameManager.finalScore;
    }
}
