using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCard : MonoBehaviour {

    ScoreKeeper scoreKeeper;
    Text text;

	// Use this for initialization
	void Start () {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        text = GetComponent<Text>();
        text.text = scoreKeeper.ScoreCard();
        //scoreKeeper.ResetScore();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
