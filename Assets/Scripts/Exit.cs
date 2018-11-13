using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {

    LevelManager levelManager;
    [SerializeField] string level;
    ScoreKeeper scoreKeeper;

	// Use this for initialization
	void Start () {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        scoreKeeper.ResetScore();
        levelManager = FindObjectOfType<LevelManager>();
	}

    private void OnTriggerEnter(Collider other)
    {
        levelManager.LoadLevel(level);
    }



}
