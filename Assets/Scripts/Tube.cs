using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour {

    Rigidbody m_rigidBody;
    [SerializeField]
    float m_speed = 1;

    // Use this for initialization
    void Start () {
        m_rigidBody = GetComponent<Rigidbody>();
        //m_rigidBody.centerOfMass = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 force = transform.forward * m_speed;
        m_rigidBody.AddTorque(force);
	}
}
