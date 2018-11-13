using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour {

    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;
    [SerializeField] GameObject button3;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisplayLevels()
    {
        Vector3 newPos = transform.position;
        newPos.y = -600;
        transform.position = newPos;
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);

    }
}
