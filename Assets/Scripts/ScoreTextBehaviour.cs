using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof (Text))]
public class ScoreTextBehaviour : MonoBehaviour {

    private Text scoreText;
    private int score = 0;

	void Start () {
        scoreText = GetComponent<Text>();
	}

    public void Add(int point)
    {
        score += point;
        scoreText.text = $"Score:{score.ToString("0000")}";
    }
}
