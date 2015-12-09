using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIscript : MonoBehaviour {

	private Text scoreText;
	public static UIscript instance;
	public int score;

//	public UIscript(int scoreP)
//	{
//		score = scoreP;
//	}

	// Use this for initialization
	void Start () {
		if (instance == null)
			instance = this;
		else if (instance != this) {
			score = instance.score;
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
		scoreText = GetComponent<Text> ();
		scoreText.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
		//scoreText.text = "Score: " + score;
	}
}
