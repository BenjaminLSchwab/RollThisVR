using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelchairFollow : MonoBehaviour {

    // Use this for initialization

    [SerializeField] float verticalOffset = 0f;
    Transform anchor;
    Transform m_player;
    void Start () {
        anchor = FindObjectOfType<CameraAnchor>().transform;
        m_player = FindObjectOfType<MovementControl>().gameObject.transform;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = m_player.position;
        newPos.y += verticalOffset;
        transform.position = newPos;
        transform.rotation = anchor.rotation;
    }
}


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnchor : MonoBehaviour {

    [SerializeField] float verticalOffset = 2.0f;
    Transform m_player;


	// Use this for initialization
	void Start () {
        m_player = FindObjectOfType<MovementControl>().gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = m_player.position;
        newPos.y += verticalOffset;
        transform.position = newPos;
	}
}

     */
