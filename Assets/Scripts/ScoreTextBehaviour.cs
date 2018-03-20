using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextBehaviour : MonoBehaviour {

    private Text scoreText;
    private int score = 0;

	void Start () {
        scoreText = GetComponent<Text>();
	}
	
	void Update () {
		
	}

    public void Add(int point)
    {
        score += point;
        scoreText.text = $"Score:{score.ToString("0000")}";
    }
}
