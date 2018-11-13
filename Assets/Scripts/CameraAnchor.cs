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
