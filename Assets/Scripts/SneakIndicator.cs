using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SneakIndicator : MonoBehaviour {

    MovementControl movementControl;
    [SerializeField] float verticalOffset;
    [SerializeField] GameObject indicator;

	// Use this for initialization
	void Start () {
        movementControl = FindObjectOfType<MovementControl>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = movementControl.transform.position;
        newPos.y += verticalOffset;

        transform.position = newPos;

        if (movementControl.sneakModifier < .9f) indicator.SetActive(true);
      
        else indicator.SetActive(false);
    }
}
