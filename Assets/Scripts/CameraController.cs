using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] Transform m_targetPos;
    [SerializeField] GameObject m_subject;
    [SerializeField] float m_speed;
    float m_distance;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        m_distance = Vector3.Magnitude(m_targetPos.position - transform.position);
        transform.position = Vector3.Slerp(transform.position, m_targetPos.position, Time.fixedDeltaTime * m_speed * (m_distance + 0.01f));
        transform.LookAt(m_subject.transform.position);
	}
}
