using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

    static ScoreKeeper instance = null;

    float time;
    int coins;
    int score;
    int deaths;


    // Update is called once per frame

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }

    }

    void Update () {
        Timer();
	}

    void Timer()
    {
        time += Time.deltaTime;
    }

    public void ResetScore()
    {
        time = 0;
        coins = 0;
        score = 0;
        deaths = 0;
    }

    public void CoinUp()
    {
        coins++;
    }

    public int GetScore()
    {
      score =  ((int)((float)((coins * 12.3) - (deaths -3))/ (time /3.14)) )* 14;
        return score;
    }

    public int GetCoins()
    {
        return coins;
    }

    public float GetTime()
    {
        return time;
    }

    public int GetDeaths()
    {
        return deaths;
    }

    public string ScoreCard()
    {

        string timeString = "";
        int mins = (int)time / 60;
        int secs = (int)(time % 60);

        if (mins == 0)
        {
            if (secs < 10)
            {

                timeString = "00:0" + secs.ToString();

            }
            else
            {
                timeString = "00:" + secs.ToString();
            }
        }
        else
        {
            if (secs < 10)
            {

                timeString = mins.ToString() + ":0" + secs.ToString();

            }
            else
            {
                timeString = mins.ToString() + ":" + secs.ToString();
            }
        }



        Debug.Log(coins.ToString() + "/3 Coins \n" + timeString + "\nScore: " + GetScore().ToString());
        return (coins.ToString() + "/3 Coins \n" + timeString + "\nScore: " + GetScore().ToString());
    }

}
