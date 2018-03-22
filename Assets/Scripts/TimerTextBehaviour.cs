using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TimerTextBehaviour : MonoBehaviour {

    private Text timerText;
    public float timer = 1f;

	void Start () {
        timerText = GetComponent<Text>();
	}
	
	void Update () {
        timer -= Time.deltaTime;

        timerText.text = $"Time:{timer.ToString("00")}";
        
		if (timer < 0f)
        {
            Debug.Log("timer zero!!!");
        }
	}
}
