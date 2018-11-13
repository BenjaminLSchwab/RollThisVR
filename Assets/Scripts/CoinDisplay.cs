using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour {

    ScoreKeeper scoreKeeper;
    Text text;

    int currentCoinCount;
    float timer;
    [SerializeField]
    float time = 2;

	// Use this for initialization
	void Start () {
        
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;


        if (currentCoinCount != scoreKeeper.GetCoins())
        {
            timer = time;
            currentCoinCount = scoreKeeper.GetCoins();
        }


        if (timer > 0)
        {


        text.text = scoreKeeper.GetCoins().ToString() + "/3";
        }
        else
        {
            text.text = "";
        }
	}
}
