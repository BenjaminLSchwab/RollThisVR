using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumoPad : MonoBehaviour {

    MovementControl player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<MovementControl>();
        Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>() );
	}
	

}
